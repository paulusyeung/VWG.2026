Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Features

    Public Class FormPropertyForm1

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles Load event of the Form
        ''' </summary>
        Private Sub FormPropertyForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ShowFormType()
        End Sub

        ''' <summary>
        ''' Handles Click event of Button 
        ''' </summary>
        Private Sub btnShowFormType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowFormType.Click
            ShowFormType()
        End Sub

        Private Sub ShowFormType()
            ' Call MessageBox to show the Form type
            MessageBox.Show(String.Format("Form type: {0}", Me.GetType()))
        End Sub
        
    End Class

End Namespace