Namespace CompanionKit.Controls.WatermarkTextBox.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class MessagePropertyPage
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
            Me.mobjWatermarkTextBox = New Gizmox.WebGUI.Forms.WatermarkTextBox()
            Me.mobjInputTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjWatermarkLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjInputLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjBottomPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjInfoPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjBottomPanel.SuspendLayout()
            Me.mobjTopPanel.SuspendLayout()
            Me.mobjInfoPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' objWatermarkTextBox
            ' 
            Me.mobjWatermarkTextBox.AllowDrag = False
            Me.mobjWatermarkTextBox.CustomStyle = "Watermark"
            Me.mobjWatermarkTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjWatermarkTextBox.Location = New System.Drawing.Point(0, 40)
            Me.mobjWatermarkTextBox.Message = "Write text here..."
            Me.mobjWatermarkTextBox.Name = "objWatermarkTextBox"
            Me.mobjWatermarkTextBox.Size = New System.Drawing.Size(200, 30)
            Me.mobjWatermarkTextBox.TabIndex = 0
            ' 
            ' objInputTextBox
            ' 
            Me.mobjInputTextBox.AllowDrag = False
            Me.mobjInputTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjInputTextBox.Location = New System.Drawing.Point(0, 40)
            Me.mobjInputTextBox.Name = "objInputTextBox"
            Me.mobjInputTextBox.Size = New System.Drawing.Size(200, 30)
            Me.mobjInputTextBox.TabIndex = 1
            ' 
            ' objButton
            ' 
            Me.mobjButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjButton.Location = New System.Drawing.Point(122, 201)
            Me.mobjButton.Name = "objButton"
            Me.mobjButton.Size = New System.Drawing.Size(200, 50)
            Me.mobjButton.TabIndex = 2
            Me.mobjButton.Text = "Set Message"
            ' 
            ' objInfoLabel
            ' 
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "objInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(193, 39)
            Me.mobjInfoLabel.TabIndex = 3
            Me.mobjInfoLabel.Text = "Enter some text to TextBox and press " & vbCr & vbLf & """Set"" to set WatermarkTextBox's" & vbCr & vbLf & "message p" + "roperty."
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' objWatermarkLabel
            ' 
            Me.mobjWatermarkLabel.AutoSize = True
            Me.mobjWatermarkLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjWatermarkLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjWatermarkLabel.Name = "objWatermarkLabel"
            Me.mobjWatermarkLabel.Size = New System.Drawing.Size(104, 13)
            Me.mobjWatermarkLabel.TabIndex = 4
            Me.mobjWatermarkLabel.Text = "WatermarkTextBox:"
            ' 
            ' objInputLabel
            ' 
            Me.mobjInputLabel.AutoSize = True
            Me.mobjInputLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjInputLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInputLabel.Name = "objInputLabel"
            Me.mobjInputLabel.Size = New System.Drawing.Size(80, 13)
            Me.mobjInputLabel.TabIndex = 5
            Me.mobjInputLabel.Text = "Input TextBox:"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 200.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjButton, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjBottomPanel, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTopPanel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjInfoPanel, 0, 0)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 7
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(445, 269)
            Me.mobjLayoutPanel.TabIndex = 6
            ' 
            ' mobjBottomPanel
            ' 
            Me.mobjBottomPanel.Controls.Add(Me.mobjInputTextBox)
            Me.mobjBottomPanel.Controls.Add(Me.mobjInputLabel)
            Me.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjBottomPanel.Location = New System.Drawing.Point(122, 121)
            Me.mobjBottomPanel.Name = "mobjBottomPanel"
            Me.mobjBottomPanel.Size = New System.Drawing.Size(200, 60)
            Me.mobjBottomPanel.TabIndex = 0
            ' 
            ' mobjTopPanel
            ' 
            Me.mobjTopPanel.Controls.Add(Me.mobjWatermarkLabel)
            Me.mobjTopPanel.Controls.Add(Me.mobjWatermarkTextBox)
            Me.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTopPanel.Location = New System.Drawing.Point(122, 41)
            Me.mobjTopPanel.Name = "mobjTopPanel"
            Me.mobjTopPanel.Size = New System.Drawing.Size(200, 60)
            Me.mobjTopPanel.TabIndex = 0
            ' 
            ' mobjInfoPanel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjInfoPanel, 3)
            Me.mobjInfoPanel.Controls.Add(Me.mobjInfoLabel)
            Me.mobjInfoPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoPanel.Name = "mobjInfoPanel"
            Me.mobjInfoPanel.Size = New System.Drawing.Size(445, 41)
            Me.mobjInfoPanel.TabIndex = 0
            ' 
            ' MessagePropertyPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(445, 300)
            Me.Text = "MessagePropertyPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjBottomPanel.ResumeLayout(False)
            Me.mobjTopPanel.ResumeLayout(False)
            Me.mobjInfoPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjWatermarkTextBox As Gizmox.WebGUI.Forms.WatermarkTextBox
        Private mobjInputTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjButton As Gizmox.WebGUI.Forms.Button
        Private mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private mobjWatermarkLabel As Gizmox.WebGUI.Forms.Label
        Private mobjInputLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjBottomPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjTopPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjInfoPanel As Gizmox.WebGUI.Forms.Panel


	End Class

End Namespace