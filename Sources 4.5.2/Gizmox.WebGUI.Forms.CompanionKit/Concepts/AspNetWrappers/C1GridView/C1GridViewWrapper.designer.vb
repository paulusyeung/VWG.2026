Namespace ComponentOneSampleAppsVB

    Partial Class C1GridViewWrapper

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
                Return GetType(C1.Web.Wijmo.Controls.C1GridView.C1GridView)
            End Get
        End Property

        ''' <summary>
        ''' Get hosted control typed instance
        ''' </summary>
        Protected ReadOnly Property HostedC1GridView As C1.Web.Wijmo.Controls.C1GridView.C1GridView
            Get
                Return CType(Me.HostedControl, C1.Web.Wijmo.Controls.C1GridView.C1GridView)
            End Get
        End Property


        ''' <summary>
        ''' A value indicating whether columns can be sized.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("A value indicating whether columns can be sized.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property AllowColSizing() As System.Boolean
            Get
                Return CType(Me.GetProperty("AllowColSizing"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("AllowColSizing", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value indicating whether columns can be sized. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AllowColSizing property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAllowColSizing() As Boolean
            Return Me.ShouldSerialize("AllowColSizing")
        End Function


        ''' <summary>
        ''' Resets the A value indicating whether columns can be sized. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AllowColSizing property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAllowColSizing()
            Me.Reset("AllowColSizing")
        End Sub


        ''' <summary>
        ''' A value indicating whether columns can be moved.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("A value indicating whether columns can be moved.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property AllowColMoving() As System.Boolean
            Get
                Return CType(Me.GetProperty("AllowColMoving"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("AllowColMoving", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value indicating whether columns can be moved. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AllowColMoving property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAllowColMoving() As Boolean
            Return Me.ShouldSerialize("AllowColMoving")
        End Function


        ''' <summary>
        ''' Resets the A value indicating whether columns can be moved. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AllowColMoving property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAllowColMoving()
            Me.Reset("AllowColMoving")
        End Sub


        ''' <summary>
        ''' A value indicating whether keyboard navigation is allowed.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("A value indicating whether keyboard navigation is allowed.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property AllowKeyboardNavigation() As System.Boolean
            Get
                Return CType(Me.GetProperty("AllowKeyboardNavigation"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("AllowKeyboardNavigation", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value indicating whether keyboard navigation is allowed. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AllowKeyboardNavigation property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAllowKeyboardNavigation() As Boolean
            Return Me.ShouldSerialize("AllowKeyboardNavigation")
        End Function


        ''' <summary>
        ''' Resets the A value indicating whether keyboard navigation is allowed. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AllowKeyboardNavigation property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAllowKeyboardNavigation()
            Me.Reset("AllowKeyboardNavigation")
        End Sub


        ''' <summary>
        ''' A value indicating whether the widget can be paged.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("A value indicating whether the widget can be paged.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property AllowPaging() As System.Boolean
            Get
                Return CType(Me.GetProperty("AllowPaging"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("AllowPaging", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value indicating whether the widget can be paged. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AllowPaging property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAllowPaging() As Boolean
            Return Me.ShouldSerialize("AllowPaging")
        End Function


        ''' <summary>
        ''' Resets the A value indicating whether the widget can be paged. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AllowPaging property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAllowPaging()
            Me.Reset("AllowPaging")
        End Sub


        ''' <summary>
        ''' A value indicating whether the widget can be sorted.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("A value indicating whether the widget can be sorted.")> _
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
        ''' Returns a boolean indicating if A value indicating whether the widget can be sorted. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AllowSorting property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAllowSorting() As Boolean
            Return Me.ShouldSerialize("AllowSorting")
        End Function


        ''' <summary>
        ''' Resets the A value indicating whether the widget can be sorted. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AllowSorting property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAllowSorting()
            Me.Reset("AllowSorting")
        End Sub


        ''' <summary>
        ''' A value indicating whether virtual scrolling is enabled.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("A value indicating whether virtual scrolling is enabled.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property AllowVirtualScrolling() As System.Boolean
            Get
                Return CType(Me.GetProperty("AllowVirtualScrolling"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("AllowVirtualScrolling", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value indicating whether virtual scrolling is enabled. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AllowVirtualScrolling property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAllowVirtualScrolling() As Boolean
            Return Me.ShouldSerialize("AllowVirtualScrolling")
        End Function


        ''' <summary>
        ''' Resets the A value indicating whether virtual scrolling is enabled. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AllowVirtualScrolling property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAllowVirtualScrolling()
            Me.Reset("AllowVirtualScrolling")
        End Sub


        ''' <summary>
        ''' Determines the freezing mode.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Determines the freezing mode.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property FreezingMode() As C1.Web.Wijmo.Controls.C1GridView.FreezingMode
            Get
                Return CType(Me.GetProperty("FreezingMode"), C1.Web.Wijmo.Controls.C1GridView.FreezingMode)
            End Get
            Set(value As C1.Web.Wijmo.Controls.C1GridView.FreezingMode)
                Me.SetProperty("FreezingMode", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Determines the freezing mode. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the FreezingMode property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeFreezingMode() As Boolean
            Return Me.ShouldSerialize("FreezingMode")
        End Function


        ''' <summary>
        ''' Resets the Determines the freezing mode. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the FreezingMode property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetFreezingMode()
            Me.Reset("FreezingMode")
        End Sub


        ''' <summary>
        ''' Determines the caption of the group area.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Determines the caption of the group area.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property GroupAreaCaption() As System.String
            Get
                Return CType(Me.GetProperty("GroupAreaCaption"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("GroupAreaCaption", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Determines the caption of the group area. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the GroupAreaCaption property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeGroupAreaCaption() As Boolean
            Return Me.ShouldSerialize("GroupAreaCaption")
        End Function


        ''' <summary>
        ''' Resets the Determines the caption of the group area. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the GroupAreaCaption property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetGroupAreaCaption()
            Me.Reset("GroupAreaCaption")
        End Sub


        ''' <summary>
        ''' Determines the indentation of the groups.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Determines the indentation of the groups.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property GroupIndent() As System.Int32
            Get
                Return CType(Me.GetProperty("GroupIndent"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("GroupIndent", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Determines the indentation of the groups. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the GroupIndent property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeGroupIndent() As Boolean
            Return Me.ShouldSerialize("GroupIndent")
        End Function


        ''' <summary>
        ''' Resets the Determines the indentation of the groups. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the GroupIndent property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetGroupIndent()
            Me.Reset("GroupIndent")
        End Sub


        ''' <summary>
        ''' Determines whether position of the current cell is highlighted or not.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Determines whether position of the current cell is highlighted or not.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property HighlightCurrentCell() As System.Boolean
            Get
                Return CType(Me.GetProperty("HighlightCurrentCell"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("HighlightCurrentCell", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Determines whether position of the current cell is highlighted or not. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the HighlightCurrentCell property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeHighlightCurrentCell() As Boolean
            Return Me.ShouldSerialize("HighlightCurrentCell")
        End Function


        ''' <summary>
        ''' Resets the Determines whether position of the current cell is highlighted or not. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the HighlightCurrentCell property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetHighlightCurrentCell()
            Me.Reset("HighlightCurrentCell")
        End Sub


        ''' <summary>
        ''' Determines the text that should be shown during callback to provide visual feedback.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Determines the text that should be shown during callback to provide visual feedback.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property LoadingText() As System.String
            Get
                Return CType(Me.GetProperty("LoadingText"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("LoadingText", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Determines the text that should be shown during callback to provide visual feedback. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the LoadingText property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeLoadingText() As Boolean
            Return Me.ShouldSerialize("LoadingText")
        End Function


        ''' <summary>
        ''' Resets the Determines the text that should be shown during callback to provide visual feedback. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the LoadingText property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetLoadingText()
            Me.Reset("LoadingText")
        End Sub


        ''' <summary>
        ''' Determines the zero-based index of the current page.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Determines the zero-based index of the current page.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property PageIndex() As System.Int32
            Get
                Return CType(Me.GetProperty("PageIndex"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("PageIndex", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Determines the zero-based index of the current page. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the PageIndex property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializePageIndex() As Boolean
            Return Me.ShouldSerialize("PageIndex")
        End Function


        ''' <summary>
        ''' Resets the Determines the zero-based index of the current page. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the PageIndex property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetPageIndex()
            Me.Reset("PageIndex")
        End Sub


        ''' <summary>
        ''' Number of rows to place on a single page.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Number of rows to place on a single page.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property PageSize() As System.Int32
            Get
                Return CType(Me.GetProperty("PageSize"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("PageSize", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Number of rows to place on a single page. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the PageSize property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializePageSize() As Boolean
            Return Me.ShouldSerialize("PageSize")
        End Function


        ''' <summary>
        ''' Resets the Number of rows to place on a single page. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the PageSize property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetPageSize()
            Me.Reset("PageSize")
        End Sub


        ''' <summary>
        ''' Pager settings.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Pager settings.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property PagerSettings As C1.Web.Wijmo.Controls.C1GridView.PagerSettings
            Get
                Return CType(Me.GetProperty("PagerSettings"), C1.Web.Wijmo.Controls.C1GridView.PagerSettings)
            End Get
        End Property


        ''' <summary>
        ''' Determines the height of a rows when virtual scrolling is used.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Determines the height of a rows when virtual scrolling is used.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property RowHeight() As System.Int32
            Get
                Return CType(Me.GetProperty("RowHeight"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("RowHeight", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Determines the height of a rows when virtual scrolling is used. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the RowHeight property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeRowHeight() As Boolean
            Return Me.ShouldSerialize("RowHeight")
        End Function


        ''' <summary>
        ''' Resets the Determines the height of a rows when virtual scrolling is used. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the RowHeight property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetRowHeight()
            Me.Reset("RowHeight")
        End Sub


        ''' <summary>
        ''' Determines the scrolling mode.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Determines the scrolling mode.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ScrollMode() As C1.Web.Wijmo.Controls.C1GridView.ScrollMode
            Get
                Return CType(Me.GetProperty("ScrollMode"), C1.Web.Wijmo.Controls.C1GridView.ScrollMode)
            End Get
            Set(value As C1.Web.Wijmo.Controls.C1GridView.ScrollMode)
                Me.SetProperty("ScrollMode", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Determines the scrolling mode. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ScrollMode property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeScrollMode() As Boolean
            Return Me.ShouldSerialize("ScrollMode")
        End Function


        ''' <summary>
        ''' Resets the Determines the scrolling mode. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ScrollMode property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetScrollMode()
            Me.Reset("ScrollMode")
        End Sub


        ''' <summary>
        ''' A value indicating whether the row header is visible.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("A value indicating whether the row header is visible.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ShowRowHeader() As System.Boolean
            Get
                Return CType(Me.GetProperty("ShowRowHeader"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("ShowRowHeader", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value indicating whether the row header is visible. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ShowRowHeader property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeShowRowHeader() As Boolean
            Return Me.ShouldSerialize("ShowRowHeader")
        End Function


        ''' <summary>
        ''' Resets the A value indicating whether the row header is visible. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ShowRowHeader property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetShowRowHeader()
            Me.Reset("ShowRowHeader")
        End Sub


        ''' <summary>
        ''' A value indicating whether filter row is visible.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("A value indicating whether filter row is visible.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ShowFilter() As System.Boolean
            Get
                Return CType(Me.GetProperty("ShowFilter"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("ShowFilter", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value indicating whether filter row is visible. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ShowFilter property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeShowFilter() As Boolean
            Return Me.ShouldSerialize("ShowFilter")
        End Function


        ''' <summary>
        ''' Resets the A value indicating whether filter row is visible. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ShowFilter property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetShowFilter()
            Me.Reset("ShowFilter")
        End Sub


        ''' <summary>
        ''' A value indicating whether footer row is visible.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("A value indicating whether footer row is visible.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ShowFooter() As System.Boolean
            Get
                Return CType(Me.GetProperty("ShowFooter"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("ShowFooter", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value indicating whether footer row is visible. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ShowFooter property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeShowFooter() As Boolean
            Return Me.ShouldSerialize("ShowFooter")
        End Function


        ''' <summary>
        ''' Resets the A value indicating whether footer row is visible. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ShowFooter property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetShowFooter()
            Me.Reset("ShowFooter")
        End Sub


        ''' <summary>
        ''' A value indicating whether group area is visible.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("A value indicating whether group area is visible.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ShowGroupArea() As System.Boolean
            Get
                Return CType(Me.GetProperty("ShowGroupArea"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("ShowGroupArea", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value indicating whether group area is visible. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ShowGroupArea property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeShowGroupArea() As Boolean
            Return Me.ShouldSerialize("ShowGroupArea")
        End Function


        ''' <summary>
        ''' Resets the A value indicating whether group area is visible. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ShowGroupArea property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetShowGroupArea()
            Me.Reset("ShowGroupArea")
        End Sub


        ''' <summary>
        ''' Indicates the index of columns that will always be shown on the left when the grid view scrolled horizontally.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Indicates the index of columns that will always be shown on the left when the grid view scrolled horizontally.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property StaticColumnIndex() As System.Int32
            Get
                Return CType(Me.GetProperty("StaticColumnIndex"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("StaticColumnIndex", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Indicates the index of columns that will always be shown on the left when the grid view scrolled horizontally. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the StaticColumnIndex property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeStaticColumnIndex() As Boolean
            Return Me.ShouldSerialize("StaticColumnIndex")
        End Function


        ''' <summary>
        ''' Resets the Indicates the index of columns that will always be shown on the left when the grid view scrolled horizontally. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the StaticColumnIndex property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetStaticColumnIndex()
            Me.Reset("StaticColumnIndex")
        End Sub


        ''' <summary>
        ''' Indicates the index of data rows that will always be shown on the top when the wijgrid is scrolled vertically.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Indicates the index of data rows that will always be shown on the top when the wijgrid is scrolled vertically.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property StaticRowIndex() As System.Int32
            Get
                Return CType(Me.GetProperty("StaticRowIndex"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("StaticRowIndex", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Indicates the index of data rows that will always be shown on the top when the wijgrid is scrolled vertically. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the StaticRowIndex property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeStaticRowIndex() As Boolean
            Return Me.ShouldSerialize("StaticRowIndex")
        End Function


        ''' <summary>
        ''' Resets the Indicates the index of data rows that will always be shown on the top when the wijgrid is scrolled vertically. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the StaticRowIndex property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetStaticRowIndex()
            Me.Reset("StaticRowIndex")
        End Sub


        ''' <summary>
        ''' C1Grid.TotalRows
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("C1Grid.TotalRows")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property TotalRows As System.Int32
            Get
                Return CType(Me.GetProperty("TotalRows"), System.Int32)
            End Get
        End Property


        ''' <summary>
        ''' A function called after editing is completed.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called after editing is completed.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientAfterCellEdit() As System.String
            Get
                Return CType(Me.GetProperty("OnClientAfterCellEdit"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientAfterCellEdit", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called after editing is completed. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientAfterCellEdit property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientAfterCellEdit() As Boolean
            Return Me.ShouldSerialize("OnClientAfterCellEdit")
        End Function


        ''' <summary>
        ''' Resets the A function called after editing is completed. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientAfterCellEdit property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientAfterCellEdit()
            Me.Reset("OnClientAfterCellEdit")
        End Sub


        ''' <summary>
        ''' A function called after a cell has been updated.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called after a cell has been updated.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientAfterCellUpdate() As System.String
            Get
                Return CType(Me.GetProperty("OnClientAfterCellUpdate"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientAfterCellUpdate", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called after a cell has been updated. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientAfterCellUpdate property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientAfterCellUpdate() As Boolean
            Return Me.ShouldSerialize("OnClientAfterCellUpdate")
        End Function


        ''' <summary>
        ''' Resets the A function called after a cell has been updated. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientAfterCellUpdate property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientAfterCellUpdate()
            Me.Reset("OnClientAfterCellUpdate")
        End Sub


        ''' <summary>
        ''' A function called before a cell enters edit mode. Cancellable.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called before a cell enters edit mode. Cancellable.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientBeforeCellEdit() As System.String
            Get
                Return CType(Me.GetProperty("OnClientBeforeCellEdit"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientBeforeCellEdit", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called before a cell enters edit mode. Cancellable. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientBeforeCellEdit property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientBeforeCellEdit() As Boolean
            Return Me.ShouldSerialize("OnClientBeforeCellEdit")
        End Function


        ''' <summary>
        ''' Resets the A function called before a cell enters edit mode. Cancellable. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientBeforeCellEdit property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientBeforeCellEdit()
            Me.Reset("OnClientBeforeCellEdit")
        End Sub


        ''' <summary>
        ''' A function called before a cell is updated.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called before a cell is updated.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientBeforeCellUpdate() As System.String
            Get
                Return CType(Me.GetProperty("OnClientBeforeCellUpdate"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientBeforeCellUpdate", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called before a cell is updated. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientBeforeCellUpdate property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientBeforeCellUpdate() As Boolean
            Return Me.ShouldSerialize("OnClientBeforeCellUpdate")
        End Function


        ''' <summary>
        ''' Resets the A function called before a cell is updated. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientBeforeCellUpdate property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientBeforeCellUpdate()
            Me.Reset("OnClientBeforeCellUpdate")
        End Sub


        ''' <summary>
        ''' A function called when column dragging is started, but before wijgrid handles the operation. Cancellable.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called when column dragging is started, but before wijgrid handles the operation. Cancellable.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientColumnDragging() As System.String
            Get
                Return CType(Me.GetProperty("OnClientColumnDragging"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientColumnDragging", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called when column dragging is started, but before wijgrid handles the operation. Cancellable. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientColumnDragging property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientColumnDragging() As Boolean
            Return Me.ShouldSerialize("OnClientColumnDragging")
        End Function


        ''' <summary>
        ''' Resets the A function called when column dragging is started, but before wijgrid handles the operation. Cancellable. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientColumnDragging property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientColumnDragging()
            Me.Reset("OnClientColumnDragging")
        End Sub


        ''' <summary>
        ''' A function called when column dragging has been started.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called when column dragging has been started.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientColumnDragged() As System.String
            Get
                Return CType(Me.GetProperty("OnClientColumnDragged"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientColumnDragged", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called when column dragging has been started. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientColumnDragged property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientColumnDragged() As Boolean
            Return Me.ShouldSerialize("OnClientColumnDragged")
        End Function


        ''' <summary>
        ''' Resets the A function called when column dragging has been started. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientColumnDragged property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientColumnDragged()
            Me.Reset("OnClientColumnDragged")
        End Sub


        ''' <summary>
        ''' A function called when column is dropped, but before wijgrid handles the operation. Cancellable.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called when column is dropped, but before wijgrid handles the operation. Cancellable.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientColumnDropping() As System.String
            Get
                Return CType(Me.GetProperty("OnClientColumnDropping"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientColumnDropping", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called when column is dropped, but before wijgrid handles the operation. Cancellable. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientColumnDropping property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientColumnDropping() As Boolean
            Return Me.ShouldSerialize("OnClientColumnDropping")
        End Function


        ''' <summary>
        ''' Resets the A function called when column is dropped, but before wijgrid handles the operation. Cancellable. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientColumnDropping property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientColumnDropping()
            Me.Reset("OnClientColumnDropping")
        End Sub


        ''' <summary>
        ''' A function called when column is dropped into the group area, but before wijgrid handles the operation. Cancellable.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called when column is dropped into the group area, but before wijgrid handles the operation. Cancellable.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientColumnGrouping() As System.String
            Get
                Return CType(Me.GetProperty("OnClientColumnGrouping"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientColumnGrouping", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called when column is dropped into the group area, but before wijgrid handles the operation. Cancellable. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientColumnGrouping property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientColumnGrouping() As Boolean
            Return Me.ShouldSerialize("OnClientColumnGrouping")
        End Function


        ''' <summary>
        ''' Resets the A function called when column is dropped into the group area, but before wijgrid handles the operation. Cancellable. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientColumnGrouping property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientColumnGrouping()
            Me.Reset("OnClientColumnGrouping")
        End Sub


        ''' <summary>
        ''' A function called when column is resized, but before wijgrid handles the operation. Cancellable.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called when column is resized, but before wijgrid handles the operation. Cancellable.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientColumnResizing() As System.String
            Get
                Return CType(Me.GetProperty("OnClientColumnResizing"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientColumnResizing", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called when column is resized, but before wijgrid handles the operation. Cancellable. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientColumnResizing property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientColumnResizing() As Boolean
            Return Me.ShouldSerialize("OnClientColumnResizing")
        End Function


        ''' <summary>
        ''' Resets the A function called when column is resized, but before wijgrid handles the operation. Cancellable. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientColumnResizing property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientColumnResizing()
            Me.Reset("OnClientColumnResizing")
        End Sub


        ''' <summary>
        ''' A function called when column has been resized.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called when column has been resized.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientColumnResized() As System.String
            Get
                Return CType(Me.GetProperty("OnClientColumnResized"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientColumnResized", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called when column has been resized. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientColumnResized property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientColumnResized() As Boolean
            Return Me.ShouldSerialize("OnClientColumnResized")
        End Function


        ''' <summary>
        ''' Resets the A function called when column has been resized. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientColumnResized property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientColumnResized()
            Me.Reset("OnClientColumnResized")
        End Sub


        ''' <summary>
        ''' A function called when column is removed from the group area, but before wijgrid handles the operation. Cancellable.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called when column is removed from the group area, but before wijgrid handles the operation. Cancellable.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientColumnUngrouping() As System.String
            Get
                Return CType(Me.GetProperty("OnClientColumnUngrouping"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientColumnUngrouping", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called when column is removed from the group area, but before wijgrid handles the operation. Cancellable. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientColumnUngrouping property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientColumnUngrouping() As Boolean
            Return Me.ShouldSerialize("OnClientColumnUngrouping")
        End Function


        ''' <summary>
        ''' Resets the A function called when column is removed from the group area, but before wijgrid handles the operation. Cancellable. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientColumnUngrouping property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientColumnUngrouping()
            Me.Reset("OnClientColumnUngrouping")
        End Sub


        ''' <summary>
        ''' A function called before the current cell is changed. Cancellable.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called before the current cell is changed. Cancellable.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientCurrentCellChanging() As System.String
            Get
                Return CType(Me.GetProperty("OnClientCurrentCellChanging"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientCurrentCellChanging", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called before the current cell is changed. Cancellable. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientCurrentCellChanging property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientCurrentCellChanging() As Boolean
            Return Me.ShouldSerialize("OnClientCurrentCellChanging")
        End Function


        ''' <summary>
        ''' Resets the A function called before the current cell is changed. Cancellable. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientCurrentCellChanging property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientCurrentCellChanging()
            Me.Reset("OnClientCurrentCellChanging")
        End Sub


        ''' <summary>
        ''' A function called after the current cell is changed.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called after the current cell is changed.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientCurrentCellChanged() As System.String
            Get
                Return CType(Me.GetProperty("OnClientCurrentCellChanged"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientCurrentCellChanged", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called after the current cell is changed. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientCurrentCellChanged property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientCurrentCellChanged() As Boolean
            Return Me.ShouldSerialize("OnClientCurrentCellChanged")
        End Function


        ''' <summary>
        ''' Resets the A function called after the current cell is changed. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientCurrentCellChanged property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientCurrentCellChanged()
            Me.Reset("OnClientCurrentCellChanged")
        End Sub


        ''' <summary>
        ''' A function called before the filter drop-down list is shown.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called before the filter drop-down list is shown.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientFilterOperatorsListShowing() As System.String
            Get
                Return CType(Me.GetProperty("OnClientFilterOperatorsListShowing"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientFilterOperatorsListShowing", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called before the filter drop-down list is shown. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientFilterOperatorsListShowing property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientFilterOperatorsListShowing() As Boolean
            Return Me.ShouldSerialize("OnClientFilterOperatorsListShowing")
        End Function


        ''' <summary>
        ''' Resets the A function called before the filter drop-down list is shown. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientFilterOperatorsListShowing property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientFilterOperatorsListShowing()
            Me.Reset("OnClientFilterOperatorsListShowing")
        End Sub


        ''' <summary>
        ''' A function called when groups are being created and the "aggregate" option of the column object has been set to "custom".
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called when groups are being created and the ""aggregate"" option of the column object has been set to ""custom"".")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientGroupAggregate() As System.String
            Get
                Return CType(Me.GetProperty("OnClientGroupAggregate"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientGroupAggregate", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called when groups are being created and the "aggregate" option of the column object has been set to "custom". should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientGroupAggregate property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientGroupAggregate() As Boolean
            Return Me.ShouldSerialize("OnClientGroupAggregate")
        End Function


        ''' <summary>
        ''' Resets the A function called when groups are being created and the "aggregate" option of the column object has been set to "custom". property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientGroupAggregate property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientGroupAggregate()
            Me.Reset("OnClientGroupAggregate")
        End Sub


        ''' <summary>
        ''' A function called when groups are being created and the groupInfo.headerText or groupInfo.FooterText of the groupInfo option has been set to "custom".
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called when groups are being created and the groupInfo.headerText or groupInfo.FooterText of the groupInfo option has been set to ""custom"".")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientGroupText() As System.String
            Get
                Return CType(Me.GetProperty("OnClientGroupText"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientGroupText", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called when groups are being created and the groupInfo.headerText or groupInfo.FooterText of the groupInfo option has been set to "custom". should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientGroupText property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientGroupText() As Boolean
            Return Me.ShouldSerialize("OnClientGroupText")
        End Function


        ''' <summary>
        ''' Resets the A function called when groups are being created and the groupInfo.headerText or groupInfo.FooterText of the groupInfo option has been set to "custom". property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientGroupText property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientGroupText()
            Me.Reset("OnClientGroupText")
        End Sub


        ''' <summary>
        ''' A function called when a cell needs to start updating but the cell value is invalid.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called when a cell needs to start updating but the cell value is invalid.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientInvalidCellValue() As System.String
            Get
                Return CType(Me.GetProperty("OnClientInvalidCellValue"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientInvalidCellValue", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called when a cell needs to start updating but the cell value is invalid. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientInvalidCellValue property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientInvalidCellValue() As Boolean
            Return Me.ShouldSerialize("OnClientInvalidCellValue")
        End Function


        ''' <summary>
        ''' Resets the A function called when a cell needs to start updating but the cell value is invalid. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientInvalidCellValue property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientInvalidCellValue()
            Me.Reset("OnClientInvalidCellValue")
        End Sub


        ''' <summary>
        ''' A function called before page index is changed. Cancellable.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called before page index is changed. Cancellable.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientPageIndexChanging() As System.String
            Get
                Return CType(Me.GetProperty("OnClientPageIndexChanging"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientPageIndexChanging", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called before page index is changed. Cancellable. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientPageIndexChanging property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientPageIndexChanging() As Boolean
            Return Me.ShouldSerialize("OnClientPageIndexChanging")
        End Function


        ''' <summary>
        ''' Resets the A function called before page index is changed. Cancellable. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientPageIndexChanging property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientPageIndexChanging()
            Me.Reset("OnClientPageIndexChanging")
        End Sub


        ''' <summary>
        ''' A function called after the selection is changed.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called after the selection is changed.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientSelectionChanged() As System.String
            Get
                Return CType(Me.GetProperty("OnClientSelectionChanged"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientSelectionChanged", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called after the selection is changed. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientSelectionChanged property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientSelectionChanged() As Boolean
            Return Me.ShouldSerialize("OnClientSelectionChanged")
        End Function


        ''' <summary>
        ''' Resets the A function called after the selection is changed. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientSelectionChanged property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientSelectionChanged()
            Me.Reset("OnClientSelectionChanged")
        End Sub


        ''' <summary>
        ''' A function called before the sorting operation is started. Cancellable.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called before the sorting operation is started. Cancellable.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientSorting() As System.String
            Get
                Return CType(Me.GetProperty("OnClientSorting"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientSorting", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called before the sorting operation is started. Cancellable. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientSorting property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientSorting() As Boolean
            Return Me.ShouldSerialize("OnClientSorting")
        End Function


        ''' <summary>
        ''' Resets the A function called before the sorting operation is started. Cancellable. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientSorting property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientSorting()
            Me.Reset("OnClientSorting")
        End Sub


        ''' <summary>
        ''' A function called when wijgrid loads a portion of data from the underlying datasource.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called when wijgrid loads a portion of data from the underlying datasource.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientDataLoading() As System.String
            Get
                Return CType(Me.GetProperty("OnClientDataLoading"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientDataLoading", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called when wijgrid loads a portion of data from the underlying datasource. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientDataLoading property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientDataLoading() As Boolean
            Return Me.ShouldSerialize("OnClientDataLoading")
        End Function


        ''' <summary>
        ''' Resets the A function called when wijgrid loads a portion of data from the underlying datasource. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientDataLoading property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientDataLoading()
            Me.Reset("OnClientDataLoading")
        End Sub


        ''' <summary>
        ''' A function called when data are loaded.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called when data are loaded.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientDataLoaded() As System.String
            Get
                Return CType(Me.GetProperty("OnClientDataLoaded"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientDataLoaded", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called when data are loaded. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientDataLoaded property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientDataLoaded() As Boolean
            Return Me.ShouldSerialize("OnClientDataLoaded")
        End Function


        ''' <summary>
        ''' Resets the A function called when data are loaded. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientDataLoaded property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientDataLoaded()
            Me.Reset("OnClientDataLoaded")
        End Sub


        ''' <summary>
        ''' A function called at the beginning of the wijgrid's lifecycle.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called at the beginning of the wijgrid's lifecycle.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientLoading() As System.String
            Get
                Return CType(Me.GetProperty("OnClientLoading"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientLoading", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called at the beginning of the wijgrid's lifecycle. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientLoading property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientLoading() As Boolean
            Return Me.ShouldSerialize("OnClientLoading")
        End Function


        ''' <summary>
        ''' Resets the A function called at the beginning of the wijgrid's lifecycle. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientLoading property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientLoading()
            Me.Reset("OnClientLoading")
        End Sub


        ''' <summary>
        ''' A function called at the end the wijgrid's lifecycle when wijgrid is filled with data and rendered.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called at the end the wijgrid's lifecycle when wijgrid is filled with data and rendered.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientLoaded() As System.String
            Get
                Return CType(Me.GetProperty("OnClientLoaded"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientLoaded", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called at the end the wijgrid's lifecycle when wijgrid is filled with data and rendered. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientLoaded property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientLoaded() As Boolean
            Return Me.ShouldSerialize("OnClientLoaded")
        End Function


        ''' <summary>
        ''' Resets the A function called at the end the wijgrid's lifecycle when wijgrid is filled with data and rendered. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientLoaded property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientLoaded()
            Me.Reset("OnClientLoaded")
        End Sub


        ''' <summary>
        ''' A function called when wijgrid is about to render.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called when wijgrid is about to render.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientRendering() As System.String
            Get
                Return CType(Me.GetProperty("OnClientRendering"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientRendering", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called when wijgrid is about to render. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientRendering property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientRendering() As Boolean
            Return Me.ShouldSerialize("OnClientRendering")
        End Function


        ''' <summary>
        ''' Resets the A function called when wijgrid is about to render. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientRendering property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientRendering()
            Me.Reset("OnClientRendering")
        End Sub


        ''' <summary>
        ''' A function called when wijgrid is rendered.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("A function called when wijgrid is rendered.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientRendered() As System.String
            Get
                Return CType(Me.GetProperty("OnClientRendered"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientRendered", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A function called when wijgrid is rendered. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientRendered property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientRendered() As Boolean
            Return Me.ShouldSerialize("OnClientRendered")
        End Function


        ''' <summary>
        ''' Resets the A function called when wijgrid is rendered. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientRendered property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientRendered()
            Me.Reset("OnClientRendered")
        End Sub


        ''' <summary>
        ''' Gets or sets a value that determines whether automatic sorting is enabled.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Sorting")> _
        <System.ComponentModel.Description("Gets or sets a value that determines whether automatic sorting is enabled.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property AllowAutoSort() As System.Boolean
            Get
                Return CType(Me.GetProperty("AllowAutoSort"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("AllowAutoSort", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Gets or sets a value that determines whether automatic sorting is enabled. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AllowAutoSort property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAllowAutoSort() As Boolean
            Return Me.ShouldSerialize("AllowAutoSort")
        End Function


        ''' <summary>
        ''' Resets the Gets or sets a value that determines whether automatic sorting is enabled. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AllowAutoSort property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAllowAutoSort()
            Me.Reset("AllowAutoSort")
        End Sub


        ''' <summary>
        ''' A value indicating whether client editing is enabled.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("A value indicating whether client editing is enabled.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property AllowClientEditing() As System.Boolean
            Get
                Return CType(Me.GetProperty("AllowClientEditing"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("AllowClientEditing", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value indicating whether client editing is enabled. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AllowClientEditing property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAllowClientEditing() As Boolean
            Return Me.ShouldSerialize("AllowClientEditing")
        End Function


        ''' <summary>
        ''' Resets the A value indicating whether client editing is enabled. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AllowClientEditing property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAllowClientEditing()
            Me.Reset("AllowClientEditing")
        End Sub


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property AllowCustomContent() As System.Boolean
            Get
                Return CType(Me.GetProperty("AllowCustomContent"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("AllowCustomContent", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if  should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AllowCustomContent property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAllowCustomContent() As Boolean
            Return Me.ShouldSerialize("AllowCustomContent")
        End Function


        ''' <summary>
        ''' Resets the  property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AllowCustomContent property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAllowCustomContent()
            Me.Reset("AllowCustomContent")
        End Sub


        ''' <summary>
        ''' Gets or sets a value that determines whether custom paging is enabled.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Category.Behavior")> _
        <System.ComponentModel.Description("Gets or sets a value that determines whether custom paging is enabled.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property AllowCustomPaging() As System.Boolean
            Get
                Return CType(Me.GetProperty("AllowCustomPaging"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("AllowCustomPaging", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Gets or sets a value that determines whether custom paging is enabled. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AllowCustomPaging property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAllowCustomPaging() As Boolean
            Return Me.ShouldSerialize("AllowCustomPaging")
        End Function


        ''' <summary>
        ''' Resets the Gets or sets a value that determines whether custom paging is enabled. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AllowCustomPaging property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAllowCustomPaging()
            Me.Reset("AllowCustomPaging")
        End Sub


        ''' <summary>
        ''' Gets or sets a value that determines whether C1BoundField objects are generated and displayed automatically.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Gets or sets a value that determines whether C1BoundField objects are generated and displayed automatically.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property AutogenerateColumns() As System.Boolean
            Get
                Return CType(Me.GetProperty("AutogenerateColumns"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("AutogenerateColumns", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Gets or sets a value that determines whether C1BoundField objects are generated and displayed automatically. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AutogenerateColumns property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAutogenerateColumns() As Boolean
            Return Me.ShouldSerialize("AutogenerateColumns")
        End Function


        ''' <summary>
        ''' Resets the Gets or sets a value that determines whether C1BoundField objects are generated and displayed automatically. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AutogenerateColumns property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAutogenerateColumns()
            Me.Reset("AutogenerateColumns")
        End Sub


        ''' <summary>
        ''' Gets or sets a value indicating whether a  C1CommandField field column with a Delete button for each data row is automatically added to a C1GridView control.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Gets or sets a value indicating whether a  C1CommandField field column with a Delete button for each data row is automatically added to a C1GridView control.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property AutoGenerateDeleteButton() As System.Boolean
            Get
                Return CType(Me.GetProperty("AutoGenerateDeleteButton"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("AutoGenerateDeleteButton", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Gets or sets a value indicating whether a  C1CommandField field column with a Delete button for each data row is automatically added to a C1GridView control. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AutoGenerateDeleteButton property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAutoGenerateDeleteButton() As Boolean
            Return Me.ShouldSerialize("AutoGenerateDeleteButton")
        End Function


        ''' <summary>
        ''' Resets the Gets or sets a value indicating whether a  C1CommandField field column with a Delete button for each data row is automatically added to a C1GridView control. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AutoGenerateDeleteButton property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAutoGenerateDeleteButton()
            Me.Reset("AutoGenerateDeleteButton")
        End Sub


        ''' <summary>
        ''' Gets or sets a value indicating whether a C1CommandField field column with an Edit button for each data row is automatically added to a C1GridView control.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Gets or sets a value indicating whether a C1CommandField field column with an Edit button for each data row is automatically added to a C1GridView control.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property AutoGenerateEditButton() As System.Boolean
            Get
                Return CType(Me.GetProperty("AutoGenerateEditButton"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("AutoGenerateEditButton", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Gets or sets a value indicating whether a C1CommandField field column with an Edit button for each data row is automatically added to a C1GridView control. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AutoGenerateEditButton property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAutoGenerateEditButton() As Boolean
            Return Me.ShouldSerialize("AutoGenerateEditButton")
        End Function


        ''' <summary>
        ''' Resets the Gets or sets a value indicating whether a C1CommandField field column with an Edit button for each data row is automatically added to a C1GridView control. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AutoGenerateEditButton property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAutoGenerateEditButton()
            Me.Reset("AutoGenerateEditButton")
        End Sub


        ''' <summary>
        ''' Gets or sets a value indicating whether a C1CommandField field column with an Filter button for the filter row is automatically added to a C1GridView control.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Gets or sets a value indicating whether a C1CommandField field column with an Filter button for the filter row is automatically added to a C1GridView control.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property AutoGenerateFilterButton() As System.Boolean
            Get
                Return CType(Me.GetProperty("AutoGenerateFilterButton"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("AutoGenerateFilterButton", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Gets or sets a value indicating whether a C1CommandField field column with an Filter button for the filter row is automatically added to a C1GridView control. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AutoGenerateFilterButton property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAutoGenerateFilterButton() As Boolean
            Return Me.ShouldSerialize("AutoGenerateFilterButton")
        End Function


        ''' <summary>
        ''' Resets the Gets or sets a value indicating whether a C1CommandField field column with an Filter button for the filter row is automatically added to a C1GridView control. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AutoGenerateFilterButton property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAutoGenerateFilterButton()
            Me.Reset("AutoGenerateFilterButton")
        End Sub


        ''' <summary>
        ''' Gets or sets a value indicating whether a C1CommandField field column with an Select button for each data row is automatically added to a C1GridView control.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Gets or sets a value indicating whether a C1CommandField field column with an Select button for each data row is automatically added to a C1GridView control.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property AutoGenerateSelectButton() As System.Boolean
            Get
                Return CType(Me.GetProperty("AutoGenerateSelectButton"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("AutoGenerateSelectButton", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Gets or sets a value indicating whether a C1CommandField field column with an Select button for each data row is automatically added to a C1GridView control. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AutoGenerateSelectButton property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAutoGenerateSelectButton() As Boolean
            Return Me.ShouldSerialize("AutoGenerateSelectButton")
        End Function


        ''' <summary>
        ''' Resets the Gets or sets a value indicating whether a C1CommandField field column with an Select button for each data row is automatically added to a C1GridView control. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AutoGenerateSelectButton property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAutoGenerateSelectButton()
            Me.Reset("AutoGenerateSelectButton")
        End Sub


        ''' <summary>
        ''' Gets the CallbackSettings object that enables you to determine actions that can be performed by the C1GridView using callbacks mechanism.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Gets the CallbackSettings object that enables you to determine actions that can be performed by the C1GridView using callbacks mechanism.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property CallbackSettings As C1.Web.Wijmo.Controls.C1GridView.CallbackSettings
            Get
                Return CType(Me.GetProperty("CallbackSettings"), C1.Web.Wijmo.Controls.C1GridView.CallbackSettings)
            End Get
        End Property


        ''' <summary>
        ''' Determines the method of sending client-side edited data to server.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Determines the method of sending client-side edited data to server.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ClientEditingUpdateMode() As C1.Web.Wijmo.Controls.C1GridView.ClientEditingUpdateMode
            Get
                Return CType(Me.GetProperty("ClientEditingUpdateMode"), C1.Web.Wijmo.Controls.C1GridView.ClientEditingUpdateMode)
            End Get
            Set(value As C1.Web.Wijmo.Controls.C1GridView.ClientEditingUpdateMode)
                Me.SetProperty("ClientEditingUpdateMode", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Determines the method of sending client-side edited data to server. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ClientEditingUpdateMode property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeClientEditingUpdateMode() As Boolean
            Return Me.ShouldSerialize("ClientEditingUpdateMode")
        End Function


        ''' <summary>
        ''' Resets the Determines the method of sending client-side edited data to server. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ClientEditingUpdateMode property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetClientEditingUpdateMode()
            Me.Reset("ClientEditingUpdateMode")
        End Sub


        ''' <summary>
        ''' Represents client-side behavior.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Represents client-side behavior.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ClientSelectionMode() As C1.Web.Wijmo.Controls.C1GridView.SelectionMode
            Get
                Return CType(Me.GetProperty("ClientSelectionMode"), C1.Web.Wijmo.Controls.C1GridView.SelectionMode)
            End Get
            Set(value As C1.Web.Wijmo.Controls.C1GridView.SelectionMode)
                Me.SetProperty("ClientSelectionMode", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Represents client-side behavior. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ClientSelectionMode property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeClientSelectionMode() As Boolean
            Return Me.ShouldSerialize("ClientSelectionMode")
        End Function


        ''' <summary>
        ''' Resets the Represents client-side behavior. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ClientSelectionMode property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetClientSelectionMode()
            Me.Reset("ClientSelectionMode")
        End Sub


        ''' <summary>
        ''' Gets a collection of objects representing the columns of the C1GridView control.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Default")> _
        <System.ComponentModel.Description("Gets a collection of objects representing the columns of the C1GridView control.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property Columns As C1.Web.Wijmo.Controls.C1GridView.C1BaseFieldCollection
            Get
                Return CType(Me.GetProperty("Columns"), C1.Web.Wijmo.Controls.C1GridView.C1BaseFieldCollection)
            End Get
        End Property


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public Property ColumnsGenerator() As System.Web.UI.IAutoFieldGenerator
            Get
                Return CType(Me.GetProperty("ColumnsGenerator"), System.Web.UI.IAutoFieldGenerator)
            End Get
            Set(value As System.Web.UI.IAutoFieldGenerator)
                Me.SetProperty("ColumnsGenerator", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if  should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ColumnsGenerator property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeColumnsGenerator() As Boolean
            Return Me.ShouldSerialize("ColumnsGenerator")
        End Function


        ''' <summary>
        ''' Resets the  property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ColumnsGenerator property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetColumnsGenerator()
            Me.Reset("ColumnsGenerator")
        End Sub


        ''' <summary>
        ''' Gets or sets an array that contains the names of the primary key fields for the items displayed in a C1GridView control.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Data")> _
        <System.ComponentModel.Description("Gets or sets an array that contains the names of the primary key fields for the items displayed in a C1GridView control.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property DataKeyNames() As System.String()
            Get
                Return CType(Me.GetProperty("DataKeyNames"), System.String())
            End Get
            Set(value As System.String())
                Me.SetProperty("DataKeyNames", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Gets or sets an array that contains the names of the primary key fields for the items displayed in a C1GridView control. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the DataKeyNames property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeDataKeyNames() As Boolean
            Return Me.ShouldSerialize("DataKeyNames")
        End Function


        ''' <summary>
        ''' Resets the Gets or sets an array that contains the names of the primary key fields for the items displayed in a C1GridView control. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the DataKeyNames property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetDataKeyNames()
            Me.Reset("DataKeyNames")
        End Sub


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property DataKeys As System.Web.UI.WebControls.DataKeyArray
            Get
                Return CType(Me.GetProperty("DataKeys"), System.Web.UI.WebControls.DataKeyArray)
            End Get
        End Property


        ''' <summary>
        ''' Gets or sets the index of the item to be edited.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Default")> _
        <System.ComponentModel.Description("Gets or sets the index of the item to be edited.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property EditIndex() As System.Int32
            Get
                Return CType(Me.GetProperty("EditIndex"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("EditIndex", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Gets or sets the index of the item to be edited. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the EditIndex property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeEditIndex() As Boolean
            Return Me.ShouldSerialize("EditIndex")
        End Function


        ''' <summary>
        ''' Resets the Gets or sets the index of the item to be edited. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the EditIndex property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetEditIndex()
            Me.Reset("EditIndex")
        End Sub


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property EmptyDataTemplate() As System.Web.UI.ITemplate
            Get
                Return CType(Me.GetProperty("EmptyDataTemplate"), System.Web.UI.ITemplate)
            End Get
            Set(value As System.Web.UI.ITemplate)
                Me.SetProperty("EmptyDataTemplate", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if  should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the EmptyDataTemplate property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeEmptyDataTemplate() As Boolean
            Return Me.ShouldSerialize("EmptyDataTemplate")
        End Function


        ''' <summary>
        ''' Resets the  property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the EmptyDataTemplate property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetEmptyDataTemplate()
            Me.Reset("EmptyDataTemplate")
        End Sub


        ''' <summary>
        ''' Gets or sets the text to display in the empty data row rendered when a C1GridView control is bound to a data source that does not contain any records.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("Gets or sets the text to display in the empty data row rendered when a C1GridView control is bound to a data source that does not contain any records.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property EmptyDataText() As System.String
            Get
                Return CType(Me.GetProperty("EmptyDataText"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("EmptyDataText", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Gets or sets the text to display in the empty data row rendered when a C1GridView control is bound to a data source that does not contain any records. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the EmptyDataText property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeEmptyDataText() As Boolean
            Return Me.ShouldSerialize("EmptyDataText")
        End Function


        ''' <summary>
        ''' Resets the Gets or sets the text to display in the empty data row rendered when a C1GridView control is bound to a data source that does not contain any records. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the EmptyDataText property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetEmptyDataText()
            Me.Reset("EmptyDataText")
        End Sub


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property FilterRow As C1.Web.Wijmo.Controls.C1GridView.C1GridViewRow
            Get
                Return CType(Me.GetProperty("FilterRow"), C1.Web.Wijmo.Controls.C1GridView.C1GridViewRow)
            End Get
        End Property


        ''' <summary>
        ''' Gets the FilterSettings object that defines the filter behaviors of the column at client-side.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Gets the FilterSettings object that defines the filter behaviors of the column at client-side.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property FilterSettings As C1.Web.Wijmo.Controls.C1GridView.FilterSettings
            Get
                Return CType(Me.GetProperty("FilterSettings"), C1.Web.Wijmo.Controls.C1GridView.FilterSettings)
            End Get
        End Property


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property FooterRow As C1.Web.Wijmo.Controls.C1GridView.C1GridViewRow
            Get
                Return CType(Me.GetProperty("FooterRow"), C1.Web.Wijmo.Controls.C1GridView.C1GridViewRow)
            End Get
        End Property


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property HeaderRow As C1.Web.Wijmo.Controls.C1GridView.C1GridViewRow
            Get
                Return CType(Me.GetProperty("HeaderRow"), C1.Web.Wijmo.Controls.C1GridView.C1GridViewRow)
            End Get
        End Property


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property PageCount As System.Int32
            Get
                Return CType(Me.GetProperty("PageCount"), System.Int32)
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
        Public ReadOnly Property PostbackReference As System.String
            Get
                Return CType(Me.GetProperty("PostbackReference"), System.String)
            End Get
        End Property


        ''' <summary>
        ''' Gets or sets the name of the column to use as the column header for the C1GridView control.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Accessibility")> _
        <System.ComponentModel.Description("Gets or sets the name of the column to use as the column header for the C1GridView control.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property RowHeaderColumn() As System.String
            Get
                Return CType(Me.GetProperty("RowHeaderColumn"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("RowHeaderColumn", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Gets or sets the name of the column to use as the column header for the C1GridView control. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the RowHeaderColumn property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeRowHeaderColumn() As Boolean
            Return Me.ShouldSerialize("RowHeaderColumn")
        End Function


        ''' <summary>
        ''' Resets the Gets or sets the name of the column to use as the column header for the C1GridView control. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the RowHeaderColumn property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetRowHeaderColumn()
            Me.Reset("RowHeaderColumn")
        End Sub


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property Rows As C1.Web.Wijmo.Controls.C1GridView.C1GridViewRowCollection
            Get
                Return CType(Me.GetProperty("Rows"), C1.Web.Wijmo.Controls.C1GridView.C1GridViewRowCollection)
            End Get
        End Property


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property SelectedDataKey As System.Web.UI.WebControls.DataKey
            Get
                Return CType(Me.GetProperty("SelectedDataKey"), System.Web.UI.WebControls.DataKey)
            End Get
        End Property


        ''' <summary>
        ''' Gets or sets the index of the selected row.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("Gets or sets the index of the selected row.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property SelectedIndex() As System.Int32
            Get
                Return CType(Me.GetProperty("SelectedIndex"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("SelectedIndex", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Gets or sets the index of the selected row. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the SelectedIndex property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeSelectedIndex() As Boolean
            Return Me.ShouldSerialize("SelectedIndex")
        End Function


        ''' <summary>
        ''' Resets the Gets or sets the index of the selected row. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the SelectedIndex property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetSelectedIndex()
            Me.Reset("SelectedIndex")
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
        Public Property SelectedPersistedDataKey() As System.Web.UI.WebControls.DataKey
            Get
                Return CType(Me.GetProperty("SelectedPersistedDataKey"), System.Web.UI.WebControls.DataKey)
            End Get
            Set(value As System.Web.UI.WebControls.DataKey)
                Me.SetProperty("SelectedPersistedDataKey", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if  should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the SelectedPersistedDataKey property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeSelectedPersistedDataKey() As Boolean
            Return Me.ShouldSerialize("SelectedPersistedDataKey")
        End Function


        ''' <summary>
        ''' Resets the  property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the SelectedPersistedDataKey property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetSelectedPersistedDataKey()
            Me.Reset("SelectedPersistedDataKey")
        End Sub


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property SelectedRow As C1.Web.Wijmo.Controls.C1GridView.C1GridViewRow
            Get
                Return CType(Me.GetProperty("SelectedRow"), C1.Web.Wijmo.Controls.C1GridView.C1GridViewRow)
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
        Public ReadOnly Property SelectedValue As System.Object
            Get
                Return CType(Me.GetProperty("SelectedValue"), System.Object)
            End Get
        End Property


        ''' <summary>
        ''' Determines whether the header is displayed.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("Determines whether the header is displayed.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ShowHeader() As System.Boolean
            Get
                Return CType(Me.GetProperty("ShowHeader"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("ShowHeader", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Determines whether the header is displayed. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ShowHeader property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeShowHeader() As Boolean
            Return Me.ShouldSerialize("ShowHeader")
        End Function


        ''' <summary>
        ''' Resets the Determines whether the header is displayed. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ShowHeader property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetShowHeader()
            Me.Reset("ShowHeader")
        End Sub


        ''' <summary>
        ''' Gets or sets a value indicating whether a C1GridView control renders its header in an accessible format.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Accessibility")> _
        <System.ComponentModel.Description("Gets or sets a value indicating whether a C1GridView control renders its header in an accessible format.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property UseAccessibleHeader() As System.Boolean
            Get
                Return CType(Me.GetProperty("UseAccessibleHeader"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("UseAccessibleHeader", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Gets or sets a value indicating whether a C1GridView control renders its header in an accessible format. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the UseAccessibleHeader property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeUseAccessibleHeader() As Boolean
            Return Me.ShouldSerialize("UseAccessibleHeader")
        End Function


        ''' <summary>
        ''' Resets the Gets or sets a value indicating whether a C1GridView control renders its header in an accessible format. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the UseAccessibleHeader property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetUseAccessibleHeader()
            Me.Reset("UseAccessibleHeader")
        End Sub


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property VirtualItemCount() As System.Int32
            Get
                Return CType(Me.GetProperty("VirtualItemCount"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("VirtualItemCount", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if  should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the VirtualItemCount property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeVirtualItemCount() As Boolean
            Return Me.ShouldSerialize("VirtualItemCount")
        End Function


        ''' <summary>
        ''' Resets the  property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the VirtualItemCount property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetVirtualItemCount()
            Me.Reset("VirtualItemCount")
        End Sub


        ''' <summary>
        ''' Gets a reference to the TableItemStyle object that enables you to set the appearance of alternating data rows in a C1GridView control.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Style")> _
        <System.ComponentModel.Description("Gets a reference to the TableItemStyle object that enables you to set the appearance of alternating data rows in a C1GridView control.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property AlternatingRowStyle As System.Web.UI.WebControls.TableItemStyle
            Get
                Return CType(Me.GetProperty("AlternatingRowStyle"), System.Web.UI.WebControls.TableItemStyle)
            End Get
        End Property


        ''' <summary>
        ''' Gets a reference to the TableItemStyle object that enables you to set the appearance of the row selected for editing in a C1GridView control.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Style")> _
        <System.ComponentModel.Description("Gets a reference to the TableItemStyle object that enables you to set the appearance of the row selected for editing in a C1GridView control.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property EditRowStyle As System.Web.UI.WebControls.TableItemStyle
            Get
                Return CType(Me.GetProperty("EditRowStyle"), System.Web.UI.WebControls.TableItemStyle)
            End Get
        End Property


        ''' <summary>
        ''' Gets a reference to the TableItemStyle object that enables you to set the appearance of the empty data row rendered when a C1GridView control is bound to a data source that does not contain any records.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Style")> _
        <System.ComponentModel.Description("Gets a reference to the TableItemStyle object that enables you to set the appearance of the empty data row rendered when a C1GridView control is bound to a data source that does not contain any records.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property EmptyDataRowStyle As System.Web.UI.WebControls.TableItemStyle
            Get
                Return CType(Me.GetProperty("EmptyDataRowStyle"), System.Web.UI.WebControls.TableItemStyle)
            End Get
        End Property


        ''' <summary>
        ''' Gets a reference to the TableItemStyle object that enables you to set the appearance of the filter row in a C1GridView control.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Style")> _
        <System.ComponentModel.Description("Gets a reference to the TableItemStyle object that enables you to set the appearance of the filter row in a C1GridView control.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property FilterStyle As System.Web.UI.WebControls.TableItemStyle
            Get
                Return CType(Me.GetProperty("FilterStyle"), System.Web.UI.WebControls.TableItemStyle)
            End Get
        End Property


        ''' <summary>
        ''' Gets a reference to the TableItemStyle object that enables you to set the appearance of the footer row in a C1GridView control.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Style")> _
        <System.ComponentModel.Description("Gets a reference to the TableItemStyle object that enables you to set the appearance of the footer row in a C1GridView control.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property FooterStyle As System.Web.UI.WebControls.TableItemStyle
            Get
                Return CType(Me.GetProperty("FooterStyle"), System.Web.UI.WebControls.TableItemStyle)
            End Get
        End Property


        ''' <summary>
        ''' Gets a reference to the TableItemStyle object that enables you to set the appearance of the header row in a C1GridView control.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Style")> _
        <System.ComponentModel.Description("Gets a reference to the TableItemStyle object that enables you to set the appearance of the header row in a C1GridView control.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property HeaderStyle As System.Web.UI.WebControls.TableItemStyle
            Get
                Return CType(Me.GetProperty("HeaderStyle"), System.Web.UI.WebControls.TableItemStyle)
            End Get
        End Property


        ''' <summary>
        ''' Gets a reference to the TableItemStyle object that enables you to set the appearance of the data rows in a C1GridView control.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Style")> _
        <System.ComponentModel.Description("Gets a reference to the TableItemStyle object that enables you to set the appearance of the data rows in a C1GridView control.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property RowStyle As System.Web.UI.WebControls.TableItemStyle
            Get
                Return CType(Me.GetProperty("RowStyle"), System.Web.UI.WebControls.TableItemStyle)
            End Get
        End Property


        ''' <summary>
        ''' Gets a reference to the TableItemStyle object that enables you to set the appearance of the selected row in a C1GridView control.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Style")> _
        <System.ComponentModel.Description("Gets a reference to the TableItemStyle object that enables you to set the appearance of the selected row in a C1GridView control.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property SelectedRowStyle As System.Web.UI.WebControls.TableItemStyle
            Get
                Return CType(Me.GetProperty("SelectedRowStyle"), System.Web.UI.WebControls.TableItemStyle)
            End Get
        End Property


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property InnerState As System.Collections.Hashtable
            Get
                Return CType(Me.GetProperty("InnerState"), System.Collections.Hashtable)
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
        ''' The collection of child controls owned by the control.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("The collection of child controls owned by the control.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property HostedControls As System.Web.UI.ControlCollection
            Get
                Return CType(Me.GetProperty("Controls"), System.Web.UI.ControlCollection)
            End Get
        End Property


        ''' <summary>
        ''' The table or view used for binding against.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Data")> _
        <System.ComponentModel.Description("The table or view used for binding against.")> _
        <System.ComponentModel.Browsable(True)> _
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



        ''' <summary>
        ''' Occurs in client editing mode when edits done by user should be persisted to underlying dataset.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs in client editing mode when edits done by user should be persisted to underlying dataset.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event BeginRowUpdate As C1.Web.Wijmo.Controls.C1GridView.C1GridViewBeginRowUpdateEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewBeginRowUpdateEventHandler)
                Me.AddEventHandler("BeginRowUpdate", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewBeginRowUpdateEventHandler)
                Me.RemoveEventHandler("BeginRowUpdate", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1GridView.C1GridViewBeginRowUpdateEventArgs)
                If (Not (Me.Events("BeginRowUpdate")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("BeginRowUpdate")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs when a column has been grouped.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs when a column has been grouped.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event ColumnGrouped As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnGroupedEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnGroupedEventHandler)
                Me.AddEventHandler("ColumnGrouped", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnGroupedEventHandler)
                Me.RemoveEventHandler("ColumnGrouped", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnGroupedEventArgs)
                If (Not (Me.Events("ColumnGrouped")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("ColumnGrouped")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs when a column is grouped, but before the C1GridView handles the operation.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs when a column is grouped, but before the C1GridView handles the operation.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event ColumnGrouping As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnGroupEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnGroupEventHandler)
                Me.AddEventHandler("ColumnGrouping", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnGroupEventHandler)
                Me.RemoveEventHandler("ColumnGrouping", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnGroupEventArgs)
                If (Not (Me.Events("ColumnGrouping")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("ColumnGrouping")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs when a column has been moved.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs when a column has been moved.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event ColumnMoved As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnMovedEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnMovedEventHandler)
                Me.AddEventHandler("ColumnMoved", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnMovedEventHandler)
                Me.RemoveEventHandler("ColumnMoved", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnMovedEventArgs)
                If (Not (Me.Events("ColumnMoved")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("ColumnMoved")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs when a column is moved, but before the C1GridView handles the operation.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs when a column is moved, but before the C1GridView handles the operation.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event ColumnMoving As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnMoveEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnMoveEventHandler)
                Me.AddEventHandler("ColumnMoving", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnMoveEventHandler)
                Me.RemoveEventHandler("ColumnMoving", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnMoveEventArgs)
                If (Not (Me.Events("ColumnMoving")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("ColumnMoving")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs when a column has been ungrouped.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs when a column has been ungrouped.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event ColumnUngrouped As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnUngroupedEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnUngroupedEventHandler)
                Me.AddEventHandler("ColumnUngrouped", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnUngroupedEventHandler)
                Me.RemoveEventHandler("ColumnUngrouped", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnUngroupedEventArgs)
                If (Not (Me.Events("ColumnUngrouped")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("ColumnUngrouped")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' OOccurs when a column is ungrouped, but before the C1GridView handles the operation.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("OOccurs when a column is ungrouped, but before the C1GridView handles the operation.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event ColumnUngrouping As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnUngroupEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnUngroupEventHandler)
                Me.AddEventHandler("ColumnUngrouping", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnUngroupEventHandler)
                Me.RemoveEventHandler("ColumnUngrouping", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnUngroupEventArgs)
                If (Not (Me.Events("ColumnUngrouping")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("ColumnUngrouping")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs in client editing mode when edits done by user should be persisted to underlying dataset.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs in client editing mode when edits done by user should be persisted to underlying dataset.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event EndRowUpdated As C1.Web.Wijmo.Controls.C1GridView.C1GridViewEndRowUpdatedEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewEndRowUpdatedEventHandler)
                Me.AddEventHandler("EndRowUpdated", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewEndRowUpdatedEventHandler)
                Me.RemoveEventHandler("EndRowUpdated", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1GridView.C1GridViewEndRowUpdatedEventArgs)
                If (Not (Me.Events("EndRowUpdated")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("EndRowUpdated")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs after filter expression is applied to the underlying DataView's RowFilter property.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs after filter expression is applied to the underlying DataView's RowFilter property.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event Filtered As System.EventHandler

            AddHandler(ByVal value As System.EventHandler)
                Me.AddEventHandler("Filtered", value)
            End AddHandler

            RemoveHandler(ByVal value As System.EventHandler)
                Me.RemoveEventHandler("Filtered", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
                If (Not (Me.Events("Filtered")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("Filtered")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs when the preparation for filtering is started but before the C1GridView instance handles the filter operation.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs when the preparation for filtering is started but before the C1GridView instance handles the filter operation.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event Filtering As C1.Web.Wijmo.Controls.C1GridView.C1GridViewFilterEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewFilterEventHandler)
                Me.AddEventHandler("Filtering", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewFilterEventHandler)
                Me.RemoveEventHandler("Filtering", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1GridView.C1GridViewFilterEventArgs)
                If (Not (Me.Events("Filtering")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("Filtering")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs when one of the pager buttons is clicked, but after the C1GridView control handles the paging operation.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs when one of the pager buttons is clicked, but after the C1GridView control handles the paging operation.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event PageIndexChanged As System.EventHandler

            AddHandler(ByVal value As System.EventHandler)
                Me.AddEventHandler("PageIndexChanged", value)
            End AddHandler

            RemoveHandler(ByVal value As System.EventHandler)
                Me.RemoveEventHandler("PageIndexChanged", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
                If (Not (Me.Events("PageIndexChanged")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("PageIndexChanged")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs when one of the pager buttons is clicked, but before the C1GridView control handles the paging operation.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs when one of the pager buttons is clicked, but before the C1GridView control handles the paging operation.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event PageIndexChanging As C1.Web.Wijmo.Controls.C1GridView.C1GridViewPageEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewPageEventHandler)
                Me.AddEventHandler("PageIndexChanging", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewPageEventHandler)
                Me.RemoveEventHandler("PageIndexChanging", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1GridView.C1GridViewPageEventArgs)
                If (Not (Me.Events("PageIndexChanging")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("PageIndexChanging")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs when the Cancel button of a item in edit mode is clicked, but before the item exits edit mode.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs when the Cancel button of a item in edit mode is clicked, but before the item exits edit mode.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event RowCancelingEdit As C1.Web.Wijmo.Controls.C1GridView.C1GridViewCancelEditEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewCancelEditEventHandler)
                Me.AddEventHandler("RowCancelingEdit", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewCancelEditEventHandler)
                Me.RemoveEventHandler("RowCancelingEdit", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1GridView.C1GridViewCancelEditEventArgs)
                If (Not (Me.Events("RowCancelingEdit")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("RowCancelingEdit")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs when a button is clicked in a C1GridView control.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs when a button is clicked in a C1GridView control.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event RowCommand As C1.Web.Wijmo.Controls.C1GridView.C1GridViewCommandEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewCommandEventHandler)
                Me.AddEventHandler("RowCommand", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewCommandEventHandler)
                Me.RemoveEventHandler("RowCommand", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1GridView.C1GridViewCommandEventArgs)
                If (Not (Me.Events("RowCommand")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("RowCommand")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs when a row is created in a C1GridView control.
        ''' </summary>
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Occurs when a row is created in a C1GridView control.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event RowCreated As C1.Web.Wijmo.Controls.C1GridView.C1GridViewRowEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewRowEventHandler)
                Me.AddEventHandler("RowCreated", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewRowEventHandler)
                Me.RemoveEventHandler("RowCreated", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1GridView.C1GridViewRowEventArgs)
                If (Not (Me.Events("RowCreated")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("RowCreated")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs when a row is bound to data in a C1GridView control.
        ''' </summary>
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Occurs when a row is bound to data in a C1GridView control.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event RowDataBound As C1.Web.Wijmo.Controls.C1GridView.C1GridViewRowEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewRowEventHandler)
                Me.AddEventHandler("RowDataBound", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewRowEventHandler)
                Me.RemoveEventHandler("RowDataBound", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1GridView.C1GridViewRowEventArgs)
                If (Not (Me.Events("RowDataBound")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("RowDataBound")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' occurs when the Delete button is clicked, but before the C1GridView instance handles the delete operation.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("occurs when the Delete button is clicked, but before the C1GridView instance handles the delete operation.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event RowDeleting As C1.Web.Wijmo.Controls.C1GridView.C1GridViewDeleteEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewDeleteEventHandler)
                Me.AddEventHandler("RowDeleting", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewDeleteEventHandler)
                Me.RemoveEventHandler("RowDeleting", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1GridView.C1GridViewDeleteEventArgs)
                If (Not (Me.Events("RowDeleting")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("RowDeleting")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs when the Delete button is clicked.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs when the Delete button is clicked.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event RowDeleted As C1.Web.Wijmo.Controls.C1GridView.C1GridViewDeleteEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewDeleteEventHandler)
                Me.AddEventHandler("RowDeleted", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewDeleteEventHandler)
                Me.RemoveEventHandler("RowDeleted", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1GridView.C1GridViewDeleteEventArgs)
                If (Not (Me.Events("RowDeleted")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("RowDeleted")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs when the Edit button is clicked, but before the C1GridView instance handles the operation.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs when the Edit button is clicked, but before the C1GridView instance handles the operation.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event RowEditing As C1.Web.Wijmo.Controls.C1GridView.C1GridViewEditEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewEditEventHandler)
                Me.AddEventHandler("RowEditing", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewEditEventHandler)
                Me.RemoveEventHandler("RowEditing", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1GridView.C1GridViewEditEventArgs)
                If (Not (Me.Events("RowEditing")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("RowEditing")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs when a row's Update button is clicked, but before the C1GridView control handles the update operation.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs when a row's Update button is clicked, but before the C1GridView control handles the update operation.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event RowUpdating As C1.Web.Wijmo.Controls.C1GridView.C1GridViewUpdateEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewUpdateEventHandler)
                Me.AddEventHandler("RowUpdating", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewUpdateEventHandler)
                Me.RemoveEventHandler("RowUpdating", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1GridView.C1GridViewUpdateEventArgs)
                If (Not (Me.Events("RowUpdating")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("RowUpdating")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs when a row's Update button is clicked, but after the C1GridView control handles the update operation.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs when a row's Update button is clicked, but after the C1GridView control handles the update operation.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event RowUpdated As C1.Web.Wijmo.Controls.C1GridView.C1GridViewUpdatedEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewUpdatedEventHandler)
                Me.AddEventHandler("RowUpdated", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewUpdatedEventHandler)
                Me.RemoveEventHandler("RowUpdated", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1GridView.C1GridViewUpdatedEventArgs)
                If (Not (Me.Events("RowUpdated")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("RowUpdated")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs when a row's Select button is clicked, but after the C1GridView control handles the select operation.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs when a row's Select button is clicked, but after the C1GridView control handles the select operation.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event SelectedIndexChanged As System.EventHandler

            AddHandler(ByVal value As System.EventHandler)
                Me.AddEventHandler("SelectedIndexChanged", value)
            End AddHandler

            RemoveHandler(ByVal value As System.EventHandler)
                Me.RemoveEventHandler("SelectedIndexChanged", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
                If (Not (Me.Events("SelectedIndexChanged")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("SelectedIndexChanged")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs when a row's Select button is clicked, but before the C1GridView control handles the select operation.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs when a row's Select button is clicked, but before the C1GridView control handles the select operation.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event SelectedIndexChanging As C1.Web.Wijmo.Controls.C1GridView.C1GridViewSelectEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewSelectEventHandler)
                Me.AddEventHandler("SelectedIndexChanging", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewSelectEventHandler)
                Me.RemoveEventHandler("SelectedIndexChanging", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1GridView.C1GridViewSelectEventArgs)
                If (Not (Me.Events("SelectedIndexChanging")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("SelectedIndexChanging")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs when the hyperlink to sort a column is clicked, but after the C1GridView control handles the sort operation.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs when the hyperlink to sort a column is clicked, but after the C1GridView control handles the sort operation.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event Sorted As System.EventHandler

            AddHandler(ByVal value As System.EventHandler)
                Me.AddEventHandler("Sorted", value)
            End AddHandler

            RemoveHandler(ByVal value As System.EventHandler)
                Me.RemoveEventHandler("Sorted", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
                If (Not (Me.Events("Sorted")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("Sorted")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs when the hyperlink to sort a column is clicked, but before the C1GridView control handles the sort operation.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs when the hyperlink to sort a column is clicked, but before the C1GridView control handles the sort operation.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event Sorting As C1.Web.Wijmo.Controls.C1GridView.C1GridViewSortEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewSortEventHandler)
                Me.AddEventHandler("Sorting", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1GridView.C1GridViewSortEventHandler)
                Me.RemoveEventHandler("Sorting", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1GridView.C1GridViewSortEventArgs)
                If (Not (Me.Events("Sorting")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("Sorting")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ' ''' <summary>
        ' ''' Raised before the data bound control is data binding using data methods.
        ' ''' </summary>
        '<System.ComponentModel.Category("Data")> _
        '<System.ComponentModel.Description("Raised before the data bound control is data binding using data methods.")> _
        '<System.ComponentModel.Browsable(True)> _
        'Public Custom Event CreatingModelDataSource As System.Web.UI.WebControls.CreatingModelDataSourceEventHandler

        '    AddHandler(ByVal value As System.Web.UI.WebControls.CreatingModelDataSourceEventHandler)
        '        Me.AddEventHandler("CreatingModelDataSource", value)
        '    End AddHandler

        '    RemoveHandler(ByVal value As System.Web.UI.WebControls.CreatingModelDataSourceEventHandler)
        '        Me.RemoveEventHandler("CreatingModelDataSource", value)
        '    End RemoveHandler

        '    RaiseEvent(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CreatingModelDataSourceEventArgs)
        '        If (Not (Me.Events("CreatingModelDataSource")) Is Nothing) Then
        '            Dim arrDelegate As List(Of System.Delegate) = Me.Events("CreatingModelDataSource")
        '            For Each objDelegate As System.Delegate In arrDelegate
        '                objDelegate.DynamicInvoke(New Object() {sender, e})
        '            Next
        '        End If
        '    End RaiseEvent

        'End Event



        ' ''' <summary>
        ' ''' Occurs before model methods are invoked for data operations. Handle this event if the model methods are defined on a custom type other than the code behind file.
        ' ''' </summary>
        '<System.ComponentModel.Category("Data")> _
        '<System.ComponentModel.Description("Occurs before model methods are invoked for data operations. Handle this event if the model methods are defined on a custom type other than the code behind file.")> _
        '<System.ComponentModel.Browsable(True)> _
        'Public Custom Event CallingDataMethods As System.Web.UI.WebControls.CallingDataMethodsEventHandler

        '    AddHandler(ByVal value As System.Web.UI.WebControls.CallingDataMethodsEventHandler)
        '        Me.AddEventHandler("CallingDataMethods", value)
        '    End AddHandler

        '    RemoveHandler(ByVal value As System.Web.UI.WebControls.CallingDataMethodsEventHandler)
        '        Me.RemoveEventHandler("CallingDataMethods", value)
        '    End RemoveHandler

        '    RaiseEvent(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CallingDataMethodsEventArgs)
        '        If (Not (Me.Events("CallingDataMethods")) Is Nothing) Then
        '            Dim arrDelegate As List(Of System.Delegate) = Me.Events("CallingDataMethods")
        '            For Each objDelegate As System.Delegate In arrDelegate
        '                objDelegate.DynamicInvoke(New Object() {sender, e})
        '            Next
        '        End If
        '    End RaiseEvent

        'End Event



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