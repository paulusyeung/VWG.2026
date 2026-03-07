Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Features

    Public Class ArgumentsPropertyForm
        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

        End Sub

        Private Sub ArgumentsPropertyForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Check if argument with key needed exists and 
            ' set its value to apropriate Label as a text

            If Not Context.Arguments("Color") Is Nothing Then
                lblColor.Text = String.Format("Color: {0}", Context.Arguments("Color"))
            End If

            If Not Context.Arguments("Size") Is Nothing Then
                lblSize.Text = String.Format("Size: {0}", Context.Arguments("Size"))
            End If

        End Sub

    End Class

End Namespace
