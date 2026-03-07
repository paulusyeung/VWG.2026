Imports System.Collections.Specialized

Namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Features

    Partial Public Class ArgumentsPropertyWebFormVB
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        ''' <summary>
        ''' Handles Click event of Button control
        ''' </summary>
        Protected Sub btnPass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPass.Click
            ' Create collection that will contain argument values
            Dim argumentCollection As NameValueCollection = New NameValueCollection()

            ' Add argument values to collection
            argumentCollection.Add("Color", ddlColor.SelectedValue)
            argumentCollection.Add("Size", ddlSize.SelectedValue)

            ' Clear collection from all keys and values
            FormBox.Arguments.Clear()
            ' Add collection with argument values to pass
            FormBox.Arguments.Add(argumentCollection)

            ' Reset Form value of FormBox to reload the form
            FormBox.Form = "ArgumentsPropertyForm"

        End Sub

    End Class

End Namespace