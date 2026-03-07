Namespace CompanionKit.Controls.SearchTextBox.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class SearchTextBoxIsSearchActivePage
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
            Me.components = New System.ComponentModel.Container
            Me.btnCheck = New Gizmox.WebGUI.Forms.Button
            Me.errorProvider1 = New Gizmox.WebGUI.Forms.ErrorProvider(Me.components)
            Me.searchTextBox1 = New Gizmox.WebGUI.Forms.SearchTextBox
            Me.SuspendLayout()
            '
            'btnCheck
            '
            Me.btnCheck.Location = New System.Drawing.Point(242, 23)
            Me.btnCheck.Name = "btnCheck"
            Me.btnCheck.Size = New System.Drawing.Size(86, 23)
            Me.btnCheck.TabIndex = 1
            Me.btnCheck.Text = "Check status"
            '
            'errorProvider1
            '
            Me.errorProvider1.BlinkRate = 3
            Me.errorProvider1.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError
            '
            'searchTextBox1
            '
            Me.searchTextBox1.CustomStyle = "STB"
            Me.searchTextBox1.Location = New System.Drawing.Point(17, 23)
            Me.searchTextBox1.Name = "searchTextBox1"
            Me.searchTextBox1.Size = New System.Drawing.Size(200, 20)
            Me.searchTextBox1.TabIndex = 0
            Me.searchTextBox1.WatermarkText = "Type to search"
            '
            'SearchTextBoxIsSearchActivePage
            '
            Me.Controls.Add(Me.searchTextBox1)
            Me.Controls.Add(Me.btnCheck)
            Me.Size = New System.Drawing.Size(400, 150)
            Me.Text = "SearchTextBoxIsSearchActivePage"
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents btnCheck As Gizmox.WebGUI.Forms.Button
        Private WithEvents errorProvider1 As Gizmox.WebGUI.Forms.ErrorProvider
        Private WithEvents searchTextBox1 As Gizmox.WebGUI.Forms.SearchTextBox

	End Class

End Namespace