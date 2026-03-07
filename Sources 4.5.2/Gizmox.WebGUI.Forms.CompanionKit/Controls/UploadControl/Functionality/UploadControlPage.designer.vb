Namespace CompanionKit.Controls.UploadControl.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class UploadControlPage
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
            Me.mobjUploadControl = New Gizmox.WebGUI.Forms.UploadControl()
            Me.mobjListView = New Gizmox.WebGUI.Forms.ListView()
            Me.mobjDefinedRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjCustomRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjListBox = New Gizmox.WebGUI.Forms.ListBox()
            Me.mobjExpandableGroupBox = New Gizmox.WebGUI.Forms.ExpandableGroupBox()
            Me.mobjMiddleLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjFileTypeLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjCustomInputPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjSetButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjDefinedOptionPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjCustomOptionPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjShowSpeedCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjShowFileNameCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            DirectCast(Me.mobjExpandableGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjExpandableGroupBox.SuspendLayout()
            Me.mobjMiddleLayoutPanel.SuspendLayout()
            Me.mobjGroupBox.SuspendLayout()
            Me.mobjFileTypeLayoutPanel.SuspendLayout()
            Me.mobjCustomInputPanel.SuspendLayout()
            Me.mobjDefinedOptionPanel.SuspendLayout()
            Me.mobjCustomOptionPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjUploadControl
            ' 
            Me.mobjUploadControl.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Green)
            Me.mobjUploadControl.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjUploadControl.BorderWidth = New Gizmox.WebGUI.Forms.BorderWidth(3)
            Me.mobjUploadControl.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjUploadControl.ForeColor = System.Drawing.Color.FromArgb(CInt(CByte(255)), CInt(CByte(128)), CInt(CByte(0)))
            Me.mobjUploadControl.Location = New System.Drawing.Point(0, 0)
            Me.mobjUploadControl.Name = "mobjUploadControl"
            Me.mobjUploadControl.Size = New System.Drawing.Size(1162, 130)
            Me.mobjUploadControl.TabIndex = 0
            Me.mobjUploadControl.UploadMaxFileSize = 50000000
            Me.mobjUploadControl.UploadMaxNumberOfFiles = 100
            Me.mobjUploadControl.UploadTempFilePath = "C:\Users\ygusak\AppData\Local\Temp\"
            Me.mobjUploadControl.UploadText = "Select or drop files into the ""green zone"""
            ' 
            ' mobjListView
            ' 
            Me.mobjListView.DataMember = Nothing
            Me.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListView.Location = New System.Drawing.Point(0, 396)
            Me.mobjListView.Name = "mobjListView"
            Me.mobjListView.Size = New System.Drawing.Size(1162, 273)
            Me.mobjListView.TabIndex = 3
            ' 
            ' mobjDefinedRadioButton
            ' 
            Me.mobjDefinedRadioButton.AutoSize = True
            Me.mobjDefinedRadioButton.Checked = True
            Me.mobjDefinedRadioButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDefinedRadioButton.Location = New System.Drawing.Point(0, 0)
            Me.mobjDefinedRadioButton.Name = "mobjDefinedRadioButton"
            Me.mobjDefinedRadioButton.Size = New System.Drawing.Size(400, 30)
            Me.mobjDefinedRadioButton.TabIndex = 7
            Me.mobjDefinedRadioButton.Text = "Defined"
            ' 
            ' mobjCustomRadioButton
            ' 
            Me.mobjCustomRadioButton.AutoSize = True
            Me.mobjCustomRadioButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCustomRadioButton.Location = New System.Drawing.Point(0, 0)
            Me.mobjCustomRadioButton.Name = "mobjCustomRadioButton"
            Me.mobjCustomRadioButton.Size = New System.Drawing.Size(400, 30)
            Me.mobjCustomRadioButton.TabIndex = 8
            Me.mobjCustomRadioButton.Text = "Custom"
            ' 
            ' mobjListBox
            ' 
            Me.mobjListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListBox.Items.AddRange(New Object() {"^.*$", "^.*\.(gif|png|.jpe?g)$", "^.*\.(zip|rar)$"})
            Me.mobjListBox.Location = New System.Drawing.Point(20, 70)
            Me.mobjListBox.Name = "mobjListBox"
            Me.mobjListBox.Size = New System.Drawing.Size(400, 95)
            Me.mobjListBox.TabIndex = 9
            ' 
            ' mobjExpandableGroupBox
            ' 
            Me.mobjExpandableGroupBox.Controls.Add(Me.mobjMiddleLayoutPanel)
            Me.mobjExpandableGroupBox.CustomStyle = "X"
            Me.mobjExpandableGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjExpandableGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjExpandableGroupBox.IsExpanded = False
            Me.mobjExpandableGroupBox.Location = New System.Drawing.Point(0, 130)
            Me.mobjExpandableGroupBox.Name = "mobjExpandableGroupBox"
            Me.mobjExpandableGroupBox.Size = New System.Drawing.Size(1162, 266)
            Me.mobjExpandableGroupBox.TabIndex = 10
            Me.mobjExpandableGroupBox.Text = "Options"
            ' 
            ' mobjMiddleLayoutPanel
            ' 
            Me.mobjMiddleLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjMiddleLayoutPanel.ColumnCount = 5
            Me.mobjMiddleLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjMiddleLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0F))
            Me.mobjMiddleLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjMiddleLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80.0F))
            Me.mobjMiddleLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjMiddleLayoutPanel.Controls.Add(Me.mobjGroupBox, 3, 1)
            Me.mobjMiddleLayoutPanel.Controls.Add(Me.mobjShowSpeedCheckBox, 1, 3)
            Me.mobjMiddleLayoutPanel.Controls.Add(Me.mobjShowFileNameCheckBox, 1, 1)
            Me.mobjMiddleLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjMiddleLayoutPanel.Location = New System.Drawing.Point(3, 17)
            Me.mobjMiddleLayoutPanel.Name = "mobjMiddleLayoutPanel"
            Me.mobjMiddleLayoutPanel.RowCount = 5
            Me.mobjMiddleLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjMiddleLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjMiddleLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjMiddleLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjMiddleLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjMiddleLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjMiddleLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjMiddleLayoutPanel.Size = New System.Drawing.Size(1156, 246)
            Me.mobjMiddleLayoutPanel.TabIndex = 14
            ' 
            ' mobjGroupBox
            ' 
            Me.mobjGroupBox.Controls.Add(Me.mobjFileTypeLayoutPanel)
            Me.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGroupBox.Location = New System.Drawing.Point(259, 20)
            Me.mobjGroupBox.Name = "mobjGroupBox"
            Me.mobjMiddleLayoutPanel.SetRowSpan(Me.mobjGroupBox, 3)
            Me.mobjGroupBox.Size = New System.Drawing.Size(876, 206)
            Me.mobjGroupBox.TabIndex = 0
            Me.mobjGroupBox.TabStop = False
            Me.mobjGroupBox.Text = "File type:"
            ' 
            ' mobjFileTypeLayoutPanel
            ' 
            Me.mobjFileTypeLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjFileTypeLayoutPanel.ColumnCount = 5
            Me.mobjFileTypeLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjFileTypeLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjFileTypeLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjFileTypeLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjFileTypeLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjFileTypeLayoutPanel.Controls.Add(Me.mobjListBox, 1, 3)
            Me.mobjFileTypeLayoutPanel.Controls.Add(Me.mobjCustomInputPanel, 3, 3)
            Me.mobjFileTypeLayoutPanel.Controls.Add(Me.mobjDefinedOptionPanel, 1, 1)
            Me.mobjFileTypeLayoutPanel.Controls.Add(Me.mobjCustomOptionPanel, 3, 1)
            Me.mobjFileTypeLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFileTypeLayoutPanel.Location = New System.Drawing.Point(3, 17)
            Me.mobjFileTypeLayoutPanel.Name = "mobjFileTypeLayoutPanel"
            Me.mobjFileTypeLayoutPanel.RowCount = 5
            Me.mobjFileTypeLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjFileTypeLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjFileTypeLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjFileTypeLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjFileTypeLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjFileTypeLayoutPanel.Size = New System.Drawing.Size(870, 186)
            Me.mobjFileTypeLayoutPanel.TabIndex = 11
            ' 
            ' mobjCustomInputPanel
            ' 
            Me.mobjCustomInputPanel.Controls.Add(Me.mobjSetButton)
            Me.mobjCustomInputPanel.Controls.Add(Me.mobjTextBox)
            Me.mobjCustomInputPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCustomInputPanel.Location = New System.Drawing.Point(450, 70)
            Me.mobjCustomInputPanel.Name = "mobjCustomInputPanel"
            Me.mobjCustomInputPanel.Size = New System.Drawing.Size(400, 96)
            Me.mobjCustomInputPanel.TabIndex = 0
            ' 
            ' mobjSetButton
            ' 
            Me.mobjSetButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjSetButton.Enabled = False
            Me.mobjSetButton.Location = New System.Drawing.Point(0, 56)
            Me.mobjSetButton.MinimumSize = New System.Drawing.Size(0, 40)
            Me.mobjSetButton.Name = "mobjSetButton"
            Me.mobjSetButton.Size = New System.Drawing.Size(400, 40)
            Me.mobjSetButton.TabIndex = 0
            Me.mobjSetButton.Text = "Set"
            ' 
            ' mobjTextBox
            ' 
            Me.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjTextBox.Enabled = False
            Me.mobjTextBox.Location = New System.Drawing.Point(0, 0)
            Me.mobjTextBox.MinimumSize = New System.Drawing.Size(0, 30)
            Me.mobjTextBox.Name = "mobjTextBox"
            Me.mobjTextBox.Size = New System.Drawing.Size(400, 30)
            Me.mobjTextBox.TabIndex = 10
            ' 
            ' mobjDefinedOptionPanel
            ' 
            Me.mobjDefinedOptionPanel.Controls.Add(Me.mobjDefinedRadioButton)
            Me.mobjDefinedOptionPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDefinedOptionPanel.Location = New System.Drawing.Point(20, 20)
            Me.mobjDefinedOptionPanel.Name = "mobjDefinedOptionPanel"
            Me.mobjDefinedOptionPanel.Size = New System.Drawing.Size(400, 30)
            Me.mobjDefinedOptionPanel.TabIndex = 0
            ' 
            ' mobjCustomOptionPanel
            ' 
            Me.mobjCustomOptionPanel.Controls.Add(Me.mobjCustomRadioButton)
            Me.mobjCustomOptionPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCustomOptionPanel.Location = New System.Drawing.Point(450, 20)
            Me.mobjCustomOptionPanel.Name = "mobjCustomOptionPanel"
            Me.mobjCustomOptionPanel.Size = New System.Drawing.Size(400, 30)
            Me.mobjCustomOptionPanel.TabIndex = 0
            ' 
            ' mobjShowSpeedCheckBox
            ' 
            Me.mobjShowSpeedCheckBox.AutoSize = True
            Me.mobjMiddleLayoutPanel.SetColumnSpan(Me.mobjShowSpeedCheckBox, 2)
            Me.mobjShowSpeedCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjShowSpeedCheckBox.Location = New System.Drawing.Point(20, 133)
            Me.mobjShowSpeedCheckBox.Name = "mobjShowSpeedCheckBox"
            Me.mobjShowSpeedCheckBox.Size = New System.Drawing.Size(239, 93)
            Me.mobjShowSpeedCheckBox.TabIndex = 13
            Me.mobjShowSpeedCheckBox.Text = "Show Speed"
            ' 
            ' mobjShowFileNameCheckBox
            ' 
            Me.mobjShowFileNameCheckBox.AutoSize = True
            Me.mobjMiddleLayoutPanel.SetColumnSpan(Me.mobjShowFileNameCheckBox, 2)
            Me.mobjShowFileNameCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjShowFileNameCheckBox.Location = New System.Drawing.Point(20, 20)
            Me.mobjShowFileNameCheckBox.Name = "mobjShowFileNameCheckBox"
            Me.mobjShowFileNameCheckBox.Size = New System.Drawing.Size(239, 93)
            Me.mobjShowFileNameCheckBox.TabIndex = 13
            Me.mobjShowFileNameCheckBox.Text = "Show File Name"
            ' 
            ' UploadControlPage
            ' 
            Me.Controls.Add(Me.mobjListView)
            Me.Controls.Add(Me.mobjExpandableGroupBox)
            Me.Controls.Add(Me.mobjUploadControl)
            Me.Location = New System.Drawing.Point(0, -142)
            Me.Size = New System.Drawing.Size(1162, 669)
            Me.Text = "Form1"
            DirectCast(Me.mobjExpandableGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjExpandableGroupBox.ResumeLayout(False)
            Me.mobjMiddleLayoutPanel.ResumeLayout(False)
            Me.mobjGroupBox.ResumeLayout(False)
            Me.mobjFileTypeLayoutPanel.ResumeLayout(False)
            Me.mobjCustomInputPanel.ResumeLayout(False)
            Me.mobjDefinedOptionPanel.ResumeLayout(False)
            Me.mobjCustomOptionPanel.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.mblnIsLoaded = True
        End Sub


        Private WithEvents mobjUploadControl As Gizmox.WebGUI.Forms.UploadControl
        Private WithEvents mobjListView As Gizmox.WebGUI.Forms.ListView
        Private WithEvents mobjDefinedRadioButton As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjCustomRadioButton As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjListBox As Gizmox.WebGUI.Forms.ListBox
        Private WithEvents mobjExpandableGroupBox As Gizmox.WebGUI.Forms.ExpandableGroupBox
        Private mobjFileTypeLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjMiddleLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private WithEvents mobjShowSpeedCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjShowFileNameCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private mobjGroupBox As Gizmox.WebGUI.Forms.GroupBox
        Private mobjCustomInputPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents mobjSetButton As Gizmox.WebGUI.Forms.Button
        Private mobjDefinedOptionPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjCustomOptionPanel As Gizmox.WebGUI.Forms.Panel
        Private mblnIsLoaded As Boolean
	End Class

End Namespace