Namespace CompanionKit.Controls.StatusBar.Appearance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class DifferentAppearancePage
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
            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(DifferentAppearancePage))
            Me.mobjTestStatusBar = New Gizmox.WebGUI.Forms.StatusBar()
            Me.mobjStatusBarTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjSetTextButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjFontStatusBarLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjChangeFontButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjChangeStatusBarFontDialog = New Gizmox.WebGUI.Forms.FontDialog()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjSetTextPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjChangeFontPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjSetTextPanel.SuspendLayout()
            Me.mobjChangeFontPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjTestStatusBar
            ' 
            Me.mobjTestStatusBar.BackgroundImage = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjTestStatusBar.BackgroundImage"))
            Me.mobjTestStatusBar.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Stretch
            Me.mobjTestStatusBar.Location = New System.Drawing.Point(0, 233)
            Me.mobjTestStatusBar.Name = "mobjTestStatusBar"
            Me.mobjTestStatusBar.Size = New System.Drawing.Size(508, 22)
            Me.mobjTestStatusBar.TabIndex = 0
            Me.mobjTestStatusBar.Text = "This is test StatusBar"
            ' 
            ' mobjStatusBarTextBox
            ' 
            Me.mobjStatusBarTextBox.AllowDrag = False
            Me.mobjStatusBarTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjStatusBarTextBox.Location = New System.Drawing.Point(52, 49)
            Me.mobjStatusBarTextBox.Name = "mobjStatusBarTextBox"
            Me.mobjStatusBarTextBox.Size = New System.Drawing.Size(190, 30)
            Me.mobjStatusBarTextBox.TabIndex = 1
            ' 
            ' mobjSetTextButton
            ' 
            Me.mobjSetTextButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjSetTextButton.Location = New System.Drawing.Point(0, 0)
            Me.mobjSetTextButton.MaximumSize = New System.Drawing.Size(0, 50)
            Me.mobjSetTextButton.Name = "mobjSetTextButton"
            Me.mobjSetTextButton.Size = New System.Drawing.Size(196, 50)
            Me.mobjSetTextButton.TabIndex = 2
            Me.mobjSetTextButton.Text = "Set text to StatusBar"
            Me.mobjSetTextButton.UseVisualStyleBackColor = True
            ' 
            ' mobjFontStatusBarLabel
            ' 
            Me.mobjFontStatusBarLabel.AutoSize = True
            Me.mobjFontStatusBarLabel.Location = New System.Drawing.Point(49, 126)
            Me.mobjFontStatusBarLabel.Name = "mobjFontStatusBarLabel"
            Me.mobjFontStatusBarLabel.Size = New System.Drawing.Size(0, 13)
            Me.mobjFontStatusBarLabel.TabIndex = 3
            Me.mobjFontStatusBarLabel.Dock = DockStyle.Fill
            ' 
            ' mobjChangeFontButton
            ' 
            Me.mobjChangeFontButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjChangeFontButton.Location = New System.Drawing.Point(0, 0)
            Me.mobjChangeFontButton.MaximumSize = New System.Drawing.Size(0, 50)
            Me.mobjChangeFontButton.Name = "mobjChangeFontButton"
            Me.mobjChangeFontButton.Size = New System.Drawing.Size(196, 50)
            Me.mobjChangeFontButton.TabIndex = 4
            Me.mobjChangeFontButton.Text = "Change Font of StatusBar text"
            Me.mobjChangeFontButton.UseVisualStyleBackColor = True
            ' 
            ' mobjChangeStatusBarFontDialog
            ' 
            Me.mobjChangeStatusBarFontDialog.MaxSize = 72
            Me.mobjChangeStatusBarFontDialog.MinSize = 8
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 5
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjStatusBarTextBox, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjFontStatusBarLabel, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjSetTextPanel, 3, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjChangeFontPanel, 3, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(510, 233)
            Me.mobjLayoutPanel.TabIndex = 5
            ' 
            ' mobjSetTextPanel
            ' 
            Me.mobjSetTextPanel.Controls.Add(Me.mobjSetTextButton)
            Me.mobjSetTextPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSetTextPanel.Location = New System.Drawing.Point(265, 46)
            Me.mobjSetTextPanel.Name = "mobjSetTextPanel"
            Me.mobjSetTextPanel.Size = New System.Drawing.Size(196, 60)
            Me.mobjSetTextPanel.TabIndex = 0
            ' 
            ' mobjChangeFontPanel
            ' 
            Me.mobjChangeFontPanel.Controls.Add(Me.mobjChangeFontButton)
            Me.mobjChangeFontPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjChangeFontPanel.Location = New System.Drawing.Point(265, 126)
            Me.mobjChangeFontPanel.Name = "mobjChangeFontPanel"
            Me.mobjChangeFontPanel.Size = New System.Drawing.Size(196, 60)
            Me.mobjChangeFontPanel.TabIndex = 0
            ' 
            ' DifferentAppearancePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Controls.Add(Me.mobjTestStatusBar)
            Me.Size = New System.Drawing.Size(510, 255)
            Me.Text = "DifferentAppearancePage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjSetTextPanel.ResumeLayout(False)
            Me.mobjChangeFontPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjTestStatusBar As Gizmox.WebGUI.Forms.StatusBar
        Private mobjStatusBarTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjSetTextButton As Gizmox.WebGUI.Forms.Button
        Private mobjFontStatusBarLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjChangeFontButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjChangeStatusBarFontDialog As Gizmox.WebGUI.Forms.FontDialog
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjSetTextPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjChangeFontPanel As Gizmox.WebGUI.Forms.Panel


	End Class

End Namespace
