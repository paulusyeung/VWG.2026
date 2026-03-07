Namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Features

    Partial Public Class FormPropertyWebFormVB
        Inherits System.Web.UI.Page
        ''' <summary>
        ''' Handles Load event for Page/Control
        ''' </summary>
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            ' Check if it is not post back call
            If (Not IsPostBack) Then
                ' Set Form to load inside FormBox control
                FormBox1.Form = ddlForm.SelectedValue
            End If
        End Sub

        ''' <summary>
        ''' Handles SelectedIndexChanged event of ComboBox control
        ''' </summary>
        Protected Sub ddlForm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlForm.SelectedIndexChanged
            ' Set Form to load inside FormBox control
            ' using selected value of ComboBox control
            FormBox1.Form = ddlForm.SelectedValue
        End Sub
    End Class

End Namespace