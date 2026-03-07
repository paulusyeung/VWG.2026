Namespace CompanionKit.Controls.SearchTextBox.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class SearchTextBoxDropDownMenuPropertyPage
		Inherits UserControl

		'Form overrides dispose to clean up the component list.
		<System.Diagnostics.DebuggerNonUserCode()> _
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			Try
				If disposing AndAlso components IsNot Nothing Then
					components.Dispose()
				End If
			Finally
				MyBase.Dispose(disposing)
			End Try
		End Sub

		'Required by the Visual WebGui UserControl Designer
		Private components As System.ComponentModel.IContainer

		'NOTE: The following procedure is required by the WebGui UserControl Designer
		'It can be modified using the Windows Form Designer.  
		'Do not modify it using the code editor.
		<System.Diagnostics.DebuggerStepThrough()> _
		Private Sub InitializeComponent()
            Me.contextMenu1 = New Gizmox.WebGUI.Forms.ContextMenu
            Me.searchTextBox1 = New Gizmox.WebGUI.Forms.SearchTextBox
            Me.SuspendLayout()
            '
            'searchTextBox1
            '
            Me.searchTextBox1.CustomStyle = "STB"
            Me.searchTextBox1.DropDownMenu = Me.contextMenu1
            Me.searchTextBox1.Location = New System.Drawing.Point(17, 23)
            Me.searchTextBox1.Name = "searchTextBox1"
            Me.searchTextBox1.Size = New System.Drawing.Size(200, 20)
            Me.searchTextBox1.TabIndex = 0
            '
            'SearchTextBoxDropDownMenuPropertyPage
            '
            Me.Controls.Add(Me.searchTextBox1)
            Me.Size = New System.Drawing.Size(400, 150)
            Me.Text = "SearchTextBoxDropDownMenuPropertyPage"
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents contextMenu1 As Gizmox.WebGUI.Forms.ContextMenu
        Private WithEvents searchTextBox1 As Gizmox.WebGUI.Forms.SearchTextBox

	End Class

End Namespace