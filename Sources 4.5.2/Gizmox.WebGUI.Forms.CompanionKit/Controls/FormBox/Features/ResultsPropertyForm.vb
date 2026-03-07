Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common
Imports System.Collections.Specialized


Namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Features

    Public Class ResultsPropertyForm

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
            ' Set selected indexes of ComboBox controls
            cmbColor.SelectedIndex = 0
            cmbSize.SelectedIndex = 0
        End Sub

        Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
            ' Create collection that will contain result values
            Dim results As NameValueCollection = New NameValueCollection()

            ' Add result values to collection
            results.Add("Color", cmbColor.SelectedItem.ToString())
            results.Add("Size", cmbSize.SelectedItem.ToString())

            ' Clear collection from all keys and values
            Context.Results.Clear()
            ' Add collection with result values to return
            Context.Results.Add(results)

            ' Show MessageBox window for notification
            MessageBox.Show("Results are sent")
        End Sub
    End Class

End Namespace