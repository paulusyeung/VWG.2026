Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common
Imports Gizmox.WebGUI.Forms.Client

Namespace Gizmox.WebGUI.Forms.CompanionKit.ComponentOneSampleAppsVB

    Public Class C1TreeViewForm

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

            'Set default theme for wrapper
            mobjWrapper.Theme = "aristo"
            'Set AutoPostBack property to True
            mobjWrapper.AutoPostBack = True

        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles mobjCheckBox.CheckedChanged
            'Change ShowCheckBoxes property of TreeView control
            mobjWrapper.ShowCheckBoxes = mobjCheckBox.Checked
        End Sub

        ''' <summary>
        ''' Handles the SelectedNodesChanged event of the mobjWrapper control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventArgs"/> instance containing the event data.</param>
        Private Sub mobjWrapper_SelectedNodesChanged(sender As Object, e As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventArgs) Handles mobjWrapper.SelectedNodesChanged
            'Define last selected node
            mobjLabel.Text = "Last selected node: " + e.Node.Text
        End Sub

        ''' <summary>
        ''' Handles the NodeCheckChanged event of the mobjWrapper control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventArgs"/> instance containing the event data.</param>
        Private Sub mobjWrapper_NodeCheckChanged(sender As Object, e As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventArgs) Handles mobjWrapper.NodeCheckChanged
            'Show message box if Main Node is selected
            If e.Node.Text = "Main" AndAlso e.Node.Checked Then
                MessageBox.Show("Main node is checked.")
            End If
        End Sub

    End Class

End Namespace