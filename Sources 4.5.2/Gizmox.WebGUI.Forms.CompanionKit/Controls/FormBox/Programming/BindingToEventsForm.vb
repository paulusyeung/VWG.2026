Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Programming

    Public Class BindingToEventsForm

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
        End Sub

        Protected Overrides Sub FireEvent(ByVal objEvent As Common.Interfaces.IEvent)
            ' Call base method
            MyBase.FireEvent(objEvent)
            ' Search for custom event types
            Select Case (objEvent.Type)

                Case "AddListBoxItem"
                    ' Check if key exists
                    If Not objEvent("ItemName") Is Nothing And Not String.IsNullOrEmpty(objEvent("ItemName")) Then
                        ' Add item to ListBox
                        Me.listBox.Items.Insert(0, objEvent("ItemName"))
                    End If
                    ' Update Form to display all changes
                    Me.Update()

            End Select
        End Sub

    End Class

End Namespace