Namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.ApplicationScenarios

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class DisplayPicturePage
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
            Me.mobjRepresentedPictureBox = New Gizmox.WebGUI.Forms.PictureBox()
            Me.mobjOpenFileButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjDemoOpenFileDialog = New Gizmox.WebGUI.Forms.OpenFileDialog()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            DirectCast(Me.mobjRepresentedPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjRepresentedPictureBox
            ' 
            Me.mobjRepresentedPictureBox.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Stretch
            Me.mobjRepresentedPictureBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjRepresentedPictureBox.Location = New System.Drawing.Point(63, 28)
            Me.mobjRepresentedPictureBox.Name = "mobjRepresentedPictureBox"
            Me.mobjRepresentedPictureBox.Size = New System.Drawing.Size(508, 231)
            Me.mobjRepresentedPictureBox.TabIndex = 0
            Me.mobjRepresentedPictureBox.TabStop = False
            ' 
            ' mobjOpenFileButton
            ' 
            Me.mobjOpenFileButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjOpenFileButton.Location = New System.Drawing.Point(63, 279)
            Me.mobjOpenFileButton.Name = "mobjOpenFileButton"
            Me.mobjOpenFileButton.Size = New System.Drawing.Size(508, 50)
            Me.mobjOpenFileButton.TabIndex = 1
            Me.mobjOpenFileButton.Text = "Open image file"
            Me.mobjOpenFileButton.UseVisualStyleBackColor = True
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjRepresentedPictureBox, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjOpenFileButton, 1, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(636, 359)
            Me.mobjLayoutPanel.TabIndex = 2
            ' 
            ' DisplayPicturePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(636, 359)
            Me.Text = "DisplayPicturePage"
            DirectCast(Me.mobjRepresentedPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjRepresentedPictureBox As Gizmox.WebGUI.Forms.PictureBox
        Private WithEvents mobjOpenFileButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjDemoOpenFileDialog As Gizmox.WebGUI.Forms.OpenFileDialog
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace