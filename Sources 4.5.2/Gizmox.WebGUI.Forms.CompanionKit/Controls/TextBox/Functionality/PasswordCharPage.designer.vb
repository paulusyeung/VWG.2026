Namespace CompanionKit.Controls.TextBox.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class PasswordCharPage
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
            Me.mobjTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjTextBoxLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjCharTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjPasswordCharLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjBottomPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjTopPanel.SuspendLayout()
            Me.mobjBottomPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjTextBox
            ' 
            Me.mobjTextBox.AllowDrag = False
            Me.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjTextBox.Location = New System.Drawing.Point(0, 30)
            Me.mobjTextBox.Name = "mobjTextBox"
            Me.mobjTextBox.PasswordChar = "+"c
            Me.mobjTextBox.Size = New System.Drawing.Size(200, 30)
            Me.mobjTextBox.TabIndex = 0
            ' 
            ' label1
            ' 
            Me.mobjTextBoxLabel.AutoSize = True
            Me.mobjTextBoxLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjTextBoxLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjTextBoxLabel.Name = "label1"
            Me.mobjTextBoxLabel.Size = New System.Drawing.Size(93, 13)
            Me.mobjTextBoxLabel.TabIndex = 1
            Me.mobjTextBoxLabel.Text = "PasswordTextBox"
            ' 
            ' mobjCharTextBox
            ' 
            Me.mobjCharTextBox.AllowDrag = False
            Me.mobjCharTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjCharTextBox.Location = New System.Drawing.Point(0, 30)
            Me.mobjCharTextBox.Name = "mobjCharTextBox"
            Me.mobjCharTextBox.Size = New System.Drawing.Size(200, 30)
            Me.mobjCharTextBox.TabIndex = 2
            ' 
            ' label2
            ' 
            Me.mobjPasswordCharLabel.AutoSize = True
            Me.mobjPasswordCharLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjPasswordCharLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjPasswordCharLabel.Name = "label2"
            Me.mobjPasswordCharLabel.Size = New System.Drawing.Size(76, 13)
            Me.mobjPasswordCharLabel.TabIndex = 3
            Me.mobjPasswordCharLabel.Text = "PasswordChar"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 200.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTopPanel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjBottomPanel, 1, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(401, 181)
            Me.mobjLayoutPanel.TabIndex = 4
            ' 
            ' mobjTopPanel
            ' 
            Me.mobjTopPanel.Controls.Add(Me.mobjTextBoxLabel)
            Me.mobjTopPanel.Controls.Add(Me.mobjTextBox)
            Me.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTopPanel.Location = New System.Drawing.Point(100, 20)
            Me.mobjTopPanel.Name = "mobjTopPanel"
            Me.mobjTopPanel.Size = New System.Drawing.Size(200, 60)
            Me.mobjTopPanel.TabIndex = 0
            ' 
            ' mobjBottomPanel
            ' 
            Me.mobjBottomPanel.Controls.Add(Me.mobjPasswordCharLabel)
            Me.mobjBottomPanel.Controls.Add(Me.mobjCharTextBox)
            Me.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjBottomPanel.Location = New System.Drawing.Point(100, 100)
            Me.mobjBottomPanel.Name = "mobjBottomPanel"
            Me.mobjBottomPanel.Size = New System.Drawing.Size(200, 60)
            Me.mobjBottomPanel.TabIndex = 0
            ' 
            ' PasswordCharPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(401, 181)
            Me.Text = "PasswordCharPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjTopPanel.ResumeLayout(False)
            Me.mobjBottomPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjTextBox As Global.Gizmox.WebGUI.Forms.TextBox
        Private mobjTextBoxLabel As Global.Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjCharTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjPasswordCharLabel As Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjTopPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjBottomPanel As Gizmox.WebGUI.Forms.Panel


	End Class

End Namespace
