Namespace CompanionKit.Controls.PictureBox.Functionality

	Public Class SizeModePropertyPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjSizeModeComboBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjSizeModeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjSizeModeComboBox.SelectedIndexChanged
            Me.mobjPictureBox.SizeMode = DirectCast(Me.mobjSizeModeComboBox.SelectedItem, PictureBoxSizeMode)
        End Sub

        ''' <summary>
        ''' Handles the Load event of the SizeModePropertyPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub SizeModePropertyPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Dim defaultSizeMode As PictureBoxSizeMode = Me.mobjPictureBox.SizeMode
            Me.mobjSizeModeComboBox.DataSource = System.Enum.GetValues(GetType(PictureBoxSizeMode))
            Me.mobjSizeModeComboBox.SelectedItem = defaultSizeMode

        End Sub
    End Class

End Namespace