Namespace CompanionKit.Controls.SearchTextBox.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class SearchTextBoxWatermarkTextProperty
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
            Me.button1 = New Gizmox.WebGUI.Forms.Button
            Me.label2 = New Gizmox.WebGUI.Forms.Label
            Me.textBox1 = New Gizmox.WebGUI.Forms.TextBox
            Me.label1 = New Gizmox.WebGUI.Forms.Label
            Me.searchTextBox1 = New Gizmox.WebGUI.Forms.SearchTextBox
            Me.SuspendLayout()
            '
            'button1
            '
            Me.button1.Location = New System.Drawing.Point(168, 99)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(50, 23)
            Me.button1.TabIndex = 4
            Me.button1.Text = "Set"
            '
            'label2
            '
            Me.label2.AutoSize = True
            Me.label2.Location = New System.Drawing.Point(15, 85)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(35, 13)
            Me.label2.TabIndex = 3
            Me.label2.Text = "Watermark text"
            '
            'textBox1
            '
            Me.textBox1.Location = New System.Drawing.Point(15, 101)
            Me.textBox1.Name = "textBox1"
            Me.textBox1.Size = New System.Drawing.Size(150, 20)
            Me.textBox1.TabIndex = 2
            Me.textBox1.Text = "Enter keywords to search"
            '
            'label1
            '
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(15, 15)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(35, 13)
            Me.label1.TabIndex = 1
            Me.label1.Text = "Search"
            '
            'searchTextBox1
            '
            Me.searchTextBox1.CustomStyle = "STB"
            Me.searchTextBox1.Location = New System.Drawing.Point(15, 31)
            Me.searchTextBox1.Name = "searchTextBox1"
            Me.searchTextBox1.Size = New System.Drawing.Size(203, 20)
            Me.searchTextBox1.TabIndex = 0
            '
            'SearchTextBoxWatermarkTextProperty
            '
            Me.Controls.Add(Me.searchTextBox1)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.textBox1)
            Me.Controls.Add(Me.label2)
            Me.Controls.Add(Me.button1)
            Me.Size = New System.Drawing.Size(400, 150)
            Me.Text = "SearchTextBoxWatermarkTextProperty"
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents button1 As Gizmox.WebGUI.Forms.Button
        Private WithEvents label2 As Gizmox.WebGUI.Forms.Label
        Private WithEvents textBox1 As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents label1 As Gizmox.WebGUI.Forms.Label
        Private WithEvents searchTextBox1 As Gizmox.WebGUI.Forms.SearchTextBox

	End Class

End Namespace