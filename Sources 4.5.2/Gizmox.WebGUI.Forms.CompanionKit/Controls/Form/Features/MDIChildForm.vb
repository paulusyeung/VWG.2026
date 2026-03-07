Namespace CompanionKit.Controls.Form.Features

	Public Class MDIChildForm

        ''' <summary>
        ''' Represents the MDI Child Form
        ''' </summary>
		Private _formIndex As Integer
		Public Shared _idxChildForm As Integer = 1


		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

            '  Update form name and text of label with MDI child form index
			Me.Text = (Me.Text & MDIChildForm._idxChildForm)
            Me.mobjLabel.Text = (Me.mobjLabel.Text & MDIChildForm._idxChildForm)
            Me._formIndex = MDIChildForm._idxChildForm


        End Sub

        ''' <summary>
        ''' Handles EnabledChanged event of the form
        ''' </summary>
        Private Sub MDIChildForm_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.EnabledChanged
            If Not MyBase.Enabled Then
                Me.mobjLabel.Text = ("This is Enable MDI Child Form #" & Me._formIndex)
            Else
                Me.mobjLabel.Text = ("This is Disable MDI Child Form #" & Me._formIndex)
            End If
        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjButton.Click
            MessageBox.Show(Me, "The button is clicked", "Button Click!")
        End Sub
	End Class

End Namespace
