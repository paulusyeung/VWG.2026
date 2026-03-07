Imports System.ComponentModel

Namespace CompanionKit.Controls.DataGridView.Features

    Public Class ColumnTypesPage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
           ' Add custom ComboBox column to DataGridView
            Dim mobjDataGridViewCustomComboBoxColumn As New DataGridViewCustomComboBoxColumn()
            mobjDataGridViewCustomComboBoxColumn.Width = 80
            Me.mobjDataGridView.Columns.Add(mobjDataGridViewCustomComboBoxColumn)

            ' Add custom Ellipsis column to DataGridView
            Dim mobjEllipsisColumn As New DataGridViewEllipsisColumn()
            mobjEllipsisColumn.Width = 85
            Me.mobjDataGridView.Columns.Add(mobjEllipsisColumn)

            ' Fill up DataGridView
            Dim mobjPhotoResource As Gizmox.WebGUI.Common.Resources.ResourceHandle = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle("32x32.Photo.png")
            Me.mobjDataGridView.Rows.Add(New Object() {"1", "User1", "john@gmail.com", "+18-800-1234565", True, "2000", _
             mobjPhotoResource})
            Me.mobjDataGridView.Rows.Add(New Object() {"2", "User2", "john@gmail.com", "+18-800-1234565", True, "2001", _
             mobjPhotoResource})
            Me.mobjDataGridView.Rows.Add(New Object() {"3", "User2", "john@gmail.com", "+18-800-1234565", False, "1995", _
             mobjPhotoResource})
            Me.mobjDataGridView.Rows.Add(New Object() {"4", "User3", "john@gmail.com", "+18-800-1234565", True, "1999", _
             mobjPhotoResource})
            Me.mobjDataGridView.Rows.Add(New Object() {"5", "User4", "john@gmail.com", "+18-800-1234565", False, "2009", _
             mobjPhotoResource})

            Me.RegisterEllipsisEventhandler()
        End Sub

#Region "Register Ellipsis Handler"
        Private Sub RegisterEllipsisEventhandler()
            For Each objRow As DataGridViewRow In Me.mobjDataGridView.Rows
                For Each objCell As DataGridViewCell In objRow.Cells
                    If (objCell.[GetType]() Is GetType(DataGridViewEllipsisCell)) Then
                        AddHandler DirectCast(objCell, DataGridViewEllipsisCell).Ellipsis, AddressOf Me.EllipsisEventHandler
                    End If
                Next
            Next
        End Sub

        Private Sub EllipsisEventHandler(obj As Object, e As EventArgs)
            Dim objCell As DataGridViewEllipsisCell = TryCast(obj, DataGridViewEllipsisCell)
            If objCell Is Nothing OrElse objCell.Value Is Nothing OrElse String.IsNullOrEmpty(objCell.Value.ToString().Trim()) Then
                MessageBox.Show("Ellipsis cell has no value")
            Else
                MessageBox.Show("Ellipsis cell's value = " + objCell.Value.ToString())
            End If
        End Sub
#End Region

#Region "EllipsisColumn"
        ''' <summary>
        ''' Ellipsis cell consist of a docked to right button and a docked fill TextBox
        ''' The cell's panel is used to display the controls
        ''' </summary>
        Public Class DataGridViewEllipsisCell
            Inherits DataGridViewTextBoxCell
            Private objButton As Gizmox.WebGUI.Forms.Button = Nothing
            Private objTextbox As Gizmox.WebGUI.Forms.TextBox = Nothing

            Public Event Ellipsis As EventHandler

            Public Sub New()
                MyBase.New()
                ' Get reference to cell's panel
                Dim objPanel As DataGridViewCellPanel = Me.Panel

                ' Create the button
                objButton = New Gizmox.WebGUI.Forms.Button()
                objButton.Width = 30
                objButton.Text = "..."
                objButton.Dock = DockStyle.Right
                AddHandler objButton.Click, AddressOf Me.buttonClick

                ' Create the textbox
                objTextbox = New Gizmox.WebGUI.Forms.TextBox()
                objTextbox.Dock = DockStyle.Fill

                ' Wire the TextChanged event to update the underlying cell's value
                AddHandler objTextbox.TextChanged, AddressOf Me.textChanged

                ' Add the controls
                objPanel.Controls.Add(objTextbox)
                objPanel.Controls.Add(objButton)

                ' Activate the panel
                objPanel.Visible = True
                Me.Colspan = 1
                Me.Rowspan = 1
            End Sub

            ''' <summary>
            ''' When TextBox's text is update, update to underlying cell's value
            ''' </summary>
            ''' <param name="sender"></param>
            ''' <param name="e"></param>
            Private Sub textChanged(sender As Object, e As EventArgs)
                Me.SetValue(Me.RowIndex, objTextbox.Text)
            End Sub

            ''' <summary>
            ''' When value is set, also set TextBox.Text
            ''' </summary>
            ''' <param name="intRowIndex"></param>
            ''' <param name="objValue"></param>
            ''' <returns></returns>
            Protected Overrides Function SetValue(intRowIndex As Integer, objValue As Object) As Boolean
                If objTextbox.Text <> DirectCast(objValue, String) Then
                    objTextbox.Text = DirectCast(objValue, String)
                End If
                Return MyBase.SetValue(intRowIndex, objValue)
            End Function

            ''' <summary>
            ''' Underlying cell's value always determines the value. Update TextBox.Text if required.
            ''' </summary>
            ''' <param name="intRowIndex"></param>
            ''' <returns></returns>
            Protected Overrides Function GetValue(intRowIndex As Integer) As Object
                Dim strValue As String = DirectCast(MyBase.GetValue(intRowIndex), String)
                If objTextbox.Text <> strValue Then
                    objTextbox.Text = strValue
                End If
                Return strValue
            End Function

            ''' <summary>
            ''' On Button.Click, raise the Ellipsis event for the cell
            ''' </summary>
            ''' <param name="sender"></param>
            ''' <param name="e"></param>
            Private Sub buttonClick(sender As Object, e As EventArgs)
                ' sender will be the Cell
                RaiseEvent Ellipsis(Me, EventArgs.Empty)
            End Sub

            ''' <summary>
            ''' Make sure Panel's controls follow cell's ReadOnly setting when cell is rendered
            ''' </summary>
            ''' <param name="objWriter"></param>
            Protected Overrides Sub RenderReadOnlyAttribute(objWriter As IAttributeWriter)
                If objTextbox.[ReadOnly] <> MyBase.[ReadOnly] Then
                    objTextbox.[ReadOnly] = MyBase.[ReadOnly]
                End If
                If objButton.Enabled <> Not MyBase.[ReadOnly] Then
                    objButton.Enabled = Not MyBase.[ReadOnly]
                End If
                MyBase.RenderReadOnlyAttribute(objWriter)
            End Sub

        End Class


        Public Class DataGridViewEllipsisColumn
            Inherits DataGridViewTextBoxColumn
            Public Sub New()
                MyBase.New()
                ' Set a custom template for a cell of DataGridView.
                Me.CellTemplate = New DataGridViewEllipsisCell()

                Me.HeaderText = "Ellipsis Column"
                Me.Name = "ellipsisColumn"
            End Sub

        End Class
#End Region

#Region "CustomComboboxColumn"
        Private Class DataGridViewCustomComboBoxCell
            Inherits DataGridViewComboBoxCell
            ''' <summary>
            ''' The form is used as custom DropDown control.
            ''' </summary>
            Private _treeViewForm As TreeViewComboBoxForm = Nothing

            ''' <summary>
            ''' Occurs when selected item changed.
            ''' </summary>
            Public Event ValueChanged As EventHandler

            ''' <summary>
            ''' Initializes a new instance of the <see cref="TreeViewComboBox"/> class.
            ''' </summary>
            Public Sub New()
                _treeViewForm = New TreeViewComboBoxForm()
                AddHandler _treeViewForm.Closed, AddressOf OnFormClosed
            End Sub

            ''' <summary>
            ''' Called when form is closed.
            ''' </summary>
            ''' <param name="sender">The sender.</param>
            ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
            Private Sub OnFormClosed(sender As Object, e As EventArgs)
                If DirectCast(sender, Global.Gizmox.WebGUI.Forms.Form).DialogResult = DialogResult.OK Then
                    If Me._treeViewForm.Tree.SelectedNode IsNot Nothing Then

                        Me.ValueType = GetType(String)
                        Me.Value = Me._treeViewForm.Tree.SelectedNode.Text
                    End If
                    RaiseEvent ValueChanged(Me, EventArgs.Empty)
                End If
            End Sub

            ''' <summary>
            ''' Gets a value indicating whether this instance has a custom drop down.
            ''' </summary>
            ''' <value>
            ''' 	<c>true</c> if this instance has a custom drop down; otherwise, <c>false</c>.
            ''' </value>
            Protected Overrides ReadOnly Property IsCustomDropDown() As Boolean
                Get
                    Return True
                End Get
            End Property

            ''' <summary>
            ''' Gets the custom form to display as drop down
            ''' </summary>
            ''' <returns></returns>
            Protected Overrides Function GetCustomDropDown() As Gizmox.WebGUI.Forms.Form
                _treeViewForm.DialogResult = DialogResult.None
                Return _treeViewForm

            End Function

            ''' <summary>
            ''' Make sure the selected value exists in the ComboBox's Items collection, else it will not render
            ''' </summary>
            ''' <param name="objContext"></param>
            ''' <param name="objWriter"></param>
            ''' <param name="objFormatedValue"></param>
            ''' <remarks></remarks>
            Protected Overrides Sub RenderCellValue(objContext As IContext, objWriter As IAttributeWriter, objFormatedValue As Object)
                If Me.Value IsNot Nothing Then
                    If Not Me.Items.Contains(Me.Value) Then
                        Me.Items.Add(Me.Value)
                    End If
                End If
                MyBase.RenderCellValue(objContext, objWriter, objFormatedValue)
            End Sub
        End Class

        ''' <summary>
        ''' This class represents custom column type that is inherited from the DataGridViewComboBoxColumn column type.
        ''' </summary>
        Private Class DataGridViewCustomComboBoxColumn
            Inherits DataGridViewComboBoxColumn
            Public Sub New()
                ' Set a custom template for a cell of DataGridView.
                Me.CellTemplate = New DataGridViewCustomComboBoxCell()

                ' Set dafault column property values
                Me.AutoComplete = False
                Me.AutoSizeMode = Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet
                Me.DataPropertyName = ""
                Me.DefaultCellStyle = New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
                Me.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
                Me.DisplayStyle = Gizmox.WebGUI.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton
                Me.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard
                Me.HeaderText = "Custom ComboBox"
                Me.Name = "customComboBox"
                Me.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
                Me.SortMode = Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable
                Me.Width = 100
            End Sub

        End Class
#End Region
    End Class

End Namespace