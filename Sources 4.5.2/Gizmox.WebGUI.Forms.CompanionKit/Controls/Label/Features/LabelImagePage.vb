Imports System.Drawing

Namespace CompanionKit.Controls.LabelFolder.Features

    Public Class LabelImagePage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles the Load event of the LabelImagePage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub LabelImagePage_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            ' Set selected item for ComboBox control
            Me.cmbImageAlignment.SelectedItem = Me.mobjLabel.ImageAlign
            ' Fill ComboBox with ContentAlignment enum values
            Me.cmbImageAlignment.DataSource = System.Enum.GetValues(GetType(ContentAlignment))
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the cmbImageAlignment control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub cmbImageAlignment_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbImageAlignment.SelectedIndexChanged
            ' Set image align for Label control
            Me.mobjLabel.ImageAlign = DirectCast(Me.cmbImageAlignment.SelectedItem, ContentAlignment)
        End Sub
    End Class
End Namespace