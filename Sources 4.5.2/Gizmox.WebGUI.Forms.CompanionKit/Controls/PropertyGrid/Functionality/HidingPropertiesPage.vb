Imports System.ComponentModel
Imports System.Reflection
Imports System.Collections.Generic

Namespace CompanionKit.Controls.PropertyGrid.Functionality

    Public Class HidingPropertiesPage

        Private isVisible As Boolean = False

        ''' <summary>
        ''' Indicates whether the property should be displayed in the PropertyGrid.
        ''' </summary>
        Private browsableProperties As Dictionary(Of String, Boolean) = New Dictionary(Of String, Boolean)

        ''' <summary>
        ''' Represents DemoObject that is used for demonstrating how to edit it with PropertyGrid
        ''' </summary>
        ''' <remarks></remarks>
        Private objDemoObject As DemoObject = Nothing


        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

            ' Initialize and present the object
            Me.objDemoObject = New DemoObject
            Me.lblDemoObject.Text = Me.objDemoObject.ToString


        End Sub

        ''' <summary>
        ''' Update the object presentation after been changed
        ''' </summary>
        Private Sub objPropGrid_PropertyValueChanged(ByVal s As System.Object, ByVal e As Gizmox.WebGUI.Forms.PropertyValueChangedEventArgs) Handles objPropGrid.PropertyValueChanged
            Me.lblDemoObject.Text = Me.objDemoObject.ToString

        End Sub

        ''' <summary>
        ''' Handles click event of the CheckBox that indicates whether 
        ''' selected property should be displayed in the PropertyGrid
        ''' </summary>
        Private Sub showPropertyCheckBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showPropertyCheckBox.Click
            Dim selectPropertyName As String = CStr(Me.objPropertiesComboBox.SelectedItem)

            'If ((Me.browsableProperties.Item(selectPropertyName) And Me.showPropertyCheckBox.Checked) _
            '    Or Not (Me.browsableProperties.Item(selectPropertyName) And Me.showPropertyCheckBox.Checked)) Then
            '    Return
            'End If

            Me.browsableProperties.Item(selectPropertyName) = Me.showPropertyCheckBox.Checked

            ' Update dictionary of the demo object type converter for PropertyGrid.
            ' The dictionary indicates whether the property should be displayed in the PropertyGrid.
            If ((Not DemoObjectConverter.browsableProperties Is Nothing) AndAlso (DemoObjectConverter.browsableProperties.Count = Me.browsableProperties.Count)) Then
                If DemoObjectConverter.browsableProperties.ContainsKey(selectPropertyName) Then
                    DemoObjectConverter.browsableProperties.Item(selectPropertyName) = Me.showPropertyCheckBox.Checked
                Else
                    DemoObjectConverter.browsableProperties.Add(selectPropertyName, Me.showPropertyCheckBox.Checked)
                End If
            Else
                DemoObjectConverter.browsableProperties = Me.browsableProperties
            End If

            ' Update PropertyGrid
            Me.objPropGrid.SelectedObject = Me.objDemoObject
            Me.objPropGrid.Update()

        End Sub

        ''' <summary>
        ''' Init the PropertyGrid to inspect and edit the demoobject
        ''' </summary>
        Private Sub HidingPropertiesPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim member As MemberInfo

            ' Fill up ComboBox with peoperties of demo object
            For Each member In Me.objDemoObject.GetType.GetMembers
                If (MemberTypes.Property = member.MemberType) Then
                    Dim browsable As Boolean = True
                    Dim attribute As BrowsableAttribute
                    For Each attribute In member.GetCustomAttributes(GetType(BrowsableAttribute), False)
                        If Not attribute.Browsable Then
                            browsable = False
                            Exit For
                        End If
                    Next
                    Me.browsableProperties.Add(member.Name, browsable)
                    Me.objPropertiesComboBox.Items.Add(member.Name)
                End If
            Next

            '  Set which properties shoul be displayed in the PropertyGrid control.
            DemoObjectConverter.browsableProperties = Me.browsableProperties
            ' Set demo object for the PropertyGrid
            Me.objPropGrid.SelectedObject = Me.objDemoObject
            Me.objPropertiesComboBox.SelectedIndex = 0

        End Sub

        ''' <summary>
        ''' Handles SelectedIndexChanged event of the ComboBox with demo object properties.
        ''' </summary>
        Private Sub objPropertiesComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles objPropertiesComboBox.SelectedIndexChanged
            Dim selectPropertyName As String = CStr(Me.objPropertiesComboBox.SelectedItem)
            Me.showPropertyCheckBox.Checked = Me.browsableProperties.Item(selectPropertyName)

        End Sub

        Private Sub HidingPropertiesPage_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
            isVisible = Not isVisible
            If (Not isVisible) Then
                DemoObjectConverter.browsableProperties.Clear()
            End If
        End Sub
    End Class

End Namespace