Namespace CompanionKit.Controls.CommonDialogs.ColorDialog.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class AllowFullOpenPage
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
            Me.mobjColorLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDemoColorDialog = New Gizmox.WebGUI.Forms.ColorDialog()
            Me.mobjChangeBackColorButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjChangeForeColorButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjTopPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjColorLabel
            ' 
            Me.mobjColorLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjColorLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjColorLabel.Name = "mobjColorLabel"
            Me.mobjColorLabel.Size = New System.Drawing.Size(376, 61)
            Me.mobjColorLabel.TabIndex = 0
            Me.mobjColorLabel.Text = "The label demonstrates selected colors"
            Me.mobjColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjChangeBackColorButton
            ' 
            Me.mobjChangeBackColorButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjChangeBackColorButton.Location = New System.Drawing.Point(80, 95)
            Me.mobjChangeBackColorButton.Name = "mobjChangeBackColorButton"
            Me.mobjChangeBackColorButton.Size = New System.Drawing.Size(376, 50)
            Me.mobjChangeBackColorButton.TabIndex = 1
            Me.mobjChangeBackColorButton.Text = "Set Background color"
            Me.mobjChangeBackColorButton.UseVisualStyleBackColor = True
            ' 
            ' mobjChangeForeColorButton
            ' 
            Me.mobjChangeForeColorButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjChangeForeColorButton.Location = New System.Drawing.Point(80, 165)
            Me.mobjChangeForeColorButton.Name = "mobjChangeForeColorButton"
            Me.mobjChangeForeColorButton.Size = New System.Drawing.Size(376, 50)
            Me.mobjChangeForeColorButton.TabIndex = 2
            Me.mobjChangeForeColorButton.Text = "Set Foreground color"
            Me.mobjChangeForeColorButton.UseVisualStyleBackColor = True
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjChangeForeColorButton, 1, 6)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjChangeBackColorButton, 1, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTopPanel, 1, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 8
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(538, 250)
            Me.mobjLayoutPanel.TabIndex = 3
            ' 
            ' mobjTopPanel
            ' 
            Me.mobjTopPanel.Controls.Add(Me.mobjColorLabel)
            Me.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTopPanel.Location = New System.Drawing.Point(80, 14)
            Me.mobjTopPanel.Name = "mobjTopPanel"
            Me.mobjLayoutPanel.SetRowSpan(Me.mobjTopPanel, 2)
            Me.mobjTopPanel.Size = New System.Drawing.Size(376, 61)
            Me.mobjTopPanel.TabIndex = 0
            ' 
            ' AllowFullOpenPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(538, 250)
            Me.Text = "AllowFullOpenPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjTopPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjColorLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjDemoColorDialog As Gizmox.WebGUI.Forms.ColorDialog
        Private WithEvents mobjChangeBackColorButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjChangeForeColorButton As Gizmox.WebGUI.Forms.Button
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjTopPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace
