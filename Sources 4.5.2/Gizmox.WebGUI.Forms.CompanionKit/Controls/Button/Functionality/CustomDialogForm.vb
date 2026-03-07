Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Public Class CustomDialogForm
    Public Sub New()
        InitializeComponent()
        'Applying DialogResult property for "Yes" and "No" buttons
        Me.mobjNoButton.DialogResult = Gizmox.WebGUI.Forms.DialogResult.No
        Me.mobjYesButton.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Yes
    End Sub
End Class
