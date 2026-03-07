Namespace CompanionKit.Controls.AspPageBox.Functionality
    Partial Public Class AspPageFormVB
        Inherits Gizmox.WebGUI.Forms.Hosts.AspPageBase

        Protected Button1 As System.Web.UI.WebControls.Button
        Protected form1 As System.Web.UI.HtmlControls.HtmlForm
        Protected TextBox1 As System.Web.UI.WebControls.TextBox
        Protected TextBox2 As System.Web.UI.WebControls.TextBox


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub
        Public Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Me.TextBox2.Text = Me.TextBox1.Text

        End Sub

    End Class
End Namespace