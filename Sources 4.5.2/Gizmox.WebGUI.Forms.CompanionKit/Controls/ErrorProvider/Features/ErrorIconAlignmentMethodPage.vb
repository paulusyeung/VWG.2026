Namespace CompanionKit.Controls.ErrorProvider.Features

	Public Class ErrorIconAlignmentMethodPage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles the Load event of the ErrorIconAlignmentMethodPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub ErrorIconAlignmentMethodPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Load enum ErrorIconAlignment values into 
            ' ComboBox items collection
            Me.mobjIconAlignmentCB.DataSource = System.Enum.GetValues(GetType(ErrorIconAlignment))
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjShowErrorButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjShowErrorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjShowErrorButton.Click
            ' Set ErrorIconAlignment value for ErrorProvider
            ' using ComboBox selected item value
            Me.mobjErrorProvider.SetIconAlignment(Me.mobjTextBox, DirectCast(Me.mobjIconAlignmentCB.SelectedItem, ErrorIconAlignment))
            ' Set error and message for TextBox control
            Me.mobjErrorProvider.SetError(Me.mobjTextBox, "Error occured")
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjHideErrorButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjHideErrorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjHideErrorButton.Click
            ' Remove error and message from TextBox control
            Me.mobjErrorProvider.SetError(Me.mobjTextBox, "")
        End Sub
    End Class

End Namespace