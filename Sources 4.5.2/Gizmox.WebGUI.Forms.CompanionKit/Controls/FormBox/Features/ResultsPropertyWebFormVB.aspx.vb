Namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Features

    Partial Public Class ResultsPropertyWebFormVB
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        ''' <summary>
        ''' Handles Click event of the Button control
        ''' </summary>
        Protected Sub btnGetResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetResults.Click

            ' Check if Result with key needed exists and 
            ' set its value to apropriate TextBox

            If Not FormBox.Results("Color") Is Nothing Then
                tbColor.Text = FormBox.Results("Color")
            End If

            If Not FormBox.Results("Size") Is Nothing Then
                tbSize.Text = FormBox.Results("Size")
            End If
        End Sub

    End Class

End Namespace