Namespace CompanionKit.Controls.AspPageBox.Functionality

	Public Class InteractWithASPNETPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        Private Sub InteractWithASPNETPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.demoAspPageBox.Path = "Controls\AspPageBox\Functionality\AspPageFormVB.aspx"
        End Sub

        <Serializable()> _
        Public Class MyAspPageBox
            Inherits Gizmox.WebGUI.Forms.Hosts.AspPageBox
            ' Methods
            Protected Overrides Sub FireEvent(ByVal objEvent As IEvent)
                MyBase.FireEvent(objEvent)
                If (objEvent.Type = "MessageBox") Then
                    MessageBox.Show(objEvent.Item("message"))
                End If
            End Sub

        End Class

    End Class

End Namespace