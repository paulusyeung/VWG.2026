Namespace CompanionKit.Controls.GroupBox.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class GroupBoxEnabled
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
            Me.mobjListBox = New Gizmox.WebGUI.Forms.ListBox()
            Me.mobjChkEnable = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjFirstRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjSeminarCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjGrpControls = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjAdditionalLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjSecondRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjSeminarPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjListPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjClassLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjNameLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjCheckBoxPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjGrpControls.SuspendLayout()
            Me.mobjAdditionalLayoutPanel.SuspendLayout()
            Me.mobjSeminarPanel.SuspendLayout()
            Me.mobjListPanel.SuspendLayout()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjCheckBoxPanel.SuspendLayout()
            Me.mobjTopPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjListBox
            ' 
            Me.mobjListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListBox.Items.AddRange(New Object() {"Class A", "Class B", "Class C", "Class D"})
            Me.mobjListBox.Location = New System.Drawing.Point(10, 10)
            Me.mobjListBox.Name = "mobjListBox"
            Me.mobjListBox.Size = New System.Drawing.Size(280, 43)
            Me.mobjListBox.TabIndex = 5
            ' 
            ' mobjChkEnable
            ' 
            Me.mobjChkEnable.AutoSize = True
            Me.mobjChkEnable.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjChkEnable.Location = New System.Drawing.Point(0, 0)
            Me.mobjChkEnable.Name = "mobjChkEnable"
            Me.mobjChkEnable.Size = New System.Drawing.Size(300, 30)
            Me.mobjChkEnable.TabIndex = 0
            Me.mobjChkEnable.Text = "Change details"
            ' 
            ' mobjTextBox
            ' 
            Me.mobjTextBox.AllowDrag = False
            Me.mobjTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTextBox.Location = New System.Drawing.Point(3, 52)
            Me.mobjTextBox.MaximumSize = New System.Drawing.Size(0, 30)
            Me.mobjTextBox.Name = "mobjTextBox"
            Me.mobjTextBox.Size = New System.Drawing.Size(294, 30)
            Me.mobjTextBox.TabIndex = 4
            Me.mobjTextBox.Text = "Sociology"
            ' 
            ' mobjFirstRadioButton
            ' 
            Me.mobjFirstRadioButton.AutoSize = True
            Me.mobjFirstRadioButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFirstRadioButton.ForeColor = System.Drawing.Color.DarkBlue
            Me.mobjFirstRadioButton.Location = New System.Drawing.Point(0, 88)
            Me.mobjFirstRadioButton.Name = "mobjFirstRadioButton"
            Me.mobjFirstRadioButton.Size = New System.Drawing.Size(300, 19)
            Me.mobjFirstRadioButton.TabIndex = 3
            Me.mobjFirstRadioButton.Text = "First semester"
            Me.mobjFirstRadioButton.UseVisualStyleBackColor = True
            ' 
            ' mobjSeminarCheckBox
            ' 
            Me.mobjSeminarCheckBox.AutoSize = True
            Me.mobjSeminarCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSeminarCheckBox.ForeColor = System.Drawing.Color.DarkBlue
            Me.mobjSeminarCheckBox.Location = New System.Drawing.Point(0, 0)
            Me.mobjSeminarCheckBox.Name = "mobjSeminarCheckBox"
            Me.mobjSeminarCheckBox.Size = New System.Drawing.Size(300, 30)
            Me.mobjSeminarCheckBox.TabIndex = 2
            Me.mobjSeminarCheckBox.Text = "Seminar"
            Me.mobjSeminarCheckBox.UseVisualStyleBackColor = True
            ' 
            ' mobjGrpControls
            ' 
            Me.mobjGrpControls.Controls.Add(Me.mobjAdditionalLayoutPanel)
            Me.mobjGrpControls.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGrpControls.Enabled = False
            Me.mobjGrpControls.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGrpControls.ForeColor = System.Drawing.Color.DarkBlue
            Me.mobjGrpControls.Location = New System.Drawing.Point(151, 123)
            Me.mobjGrpControls.Name = "mobjGrpControls"
            Me.mobjGrpControls.Padding = New Gizmox.WebGUI.Forms.Padding(0)
            Me.mobjGrpControls.Size = New System.Drawing.Size(300, 223)
            Me.mobjGrpControls.TabIndex = 0
            Me.mobjGrpControls.TabStop = False
            Me.mobjGrpControls.Text = "Course details"
            ' 
            ' mobjAdditionalLayoutPanel
            ' 
            Me.mobjAdditionalLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjAdditionalLayoutPanel.ColumnCount = 1
            Me.mobjAdditionalLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjSecondRadioButton, 0, 4)
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjSeminarPanel, 0, 1)
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjListPanel, 0, 6)
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjClassLabel, 0, 5)
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjNameLabel, 0, 0)
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjTextBox, 0, 2)
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjFirstRadioButton, 0, 3)
            Me.mobjAdditionalLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAdditionalLayoutPanel.Location = New System.Drawing.Point(0, 14)
            Me.mobjAdditionalLayoutPanel.Name = "mobjAdditionalLayoutPanel"
            Me.mobjAdditionalLayoutPanel.RowCount = 7
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.11111F))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 22.22222F))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.11111F))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.11111F))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 11.11111F))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjAdditionalLayoutPanel.Size = New System.Drawing.Size(300, 209)
            Me.mobjAdditionalLayoutPanel.TabIndex = 9
            ' 
            ' mobjSecondRadioButton
            ' 
            Me.mobjSecondRadioButton.AutoSize = True
            Me.mobjSecondRadioButton.Checked = True
            Me.mobjSecondRadioButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSecondRadioButton.ForeColor = System.Drawing.Color.DarkBlue
            Me.mobjSecondRadioButton.Location = New System.Drawing.Point(0, 107)
            Me.mobjSecondRadioButton.Name = "mobjSecondRadioButton"
            Me.mobjSecondRadioButton.Size = New System.Drawing.Size(300, 19)
            Me.mobjSecondRadioButton.TabIndex = 3
            Me.mobjSecondRadioButton.Text = "Second semester"
            ' 
            ' mobjSeminarPanel
            ' 
            Me.mobjSeminarPanel.Controls.Add(Me.mobjSeminarCheckBox)
            Me.mobjSeminarPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSeminarPanel.Location = New System.Drawing.Point(0, 19)
            Me.mobjSeminarPanel.Name = "mobjSeminarPanel"
            Me.mobjSeminarPanel.Size = New System.Drawing.Size(300, 30)
            Me.mobjSeminarPanel.TabIndex = 0
            ' 
            ' mobjListPanel
            ' 
            Me.mobjListPanel.Controls.Add(Me.mobjListBox)
            Me.mobjListPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListPanel.DockPadding.All = 10
            Me.mobjListPanel.Location = New System.Drawing.Point(0, 145)
            Me.mobjListPanel.Name = "mobjListPanel"
            Me.mobjListPanel.Padding = New Gizmox.WebGUI.Forms.Padding(10)
            Me.mobjListPanel.Size = New System.Drawing.Size(300, 64)
            Me.mobjListPanel.TabIndex = 0
            ' 
            ' mobjClassLabel
            ' 
            Me.mobjClassLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjClassLabel.AutoSize = True
            Me.mobjClassLabel.ForeColor = System.Drawing.Color.DarkBlue
            Me.mobjClassLabel.Location = New System.Drawing.Point(118, 129)
            Me.mobjClassLabel.Name = "mobjClassLabel"
            Me.mobjClassLabel.Size = New System.Drawing.Size(64, 13)
            Me.mobjClassLabel.TabIndex = 8
            Me.mobjClassLabel.Text = "Class rooms"
            ' 
            ' mobjNameLabel
            ' 
            Me.mobjNameLabel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjNameLabel.AutoSize = True
            Me.mobjNameLabel.ForeColor = System.Drawing.Color.DarkBlue
            Me.mobjNameLabel.Location = New System.Drawing.Point(133, 3)
            Me.mobjNameLabel.Name = "mobjNameLabel"
            Me.mobjNameLabel.Size = New System.Drawing.Size(34, 13)
            Me.mobjNameLabel.TabIndex = 8
            Me.mobjNameLabel.Text = "Name"
            ' 
            ' mobjInfoLabel
            ' 
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(602, 93)
            Me.mobjInfoLabel.TabIndex = 1
            Me.mobjInfoLabel.Text = "Switch checkbox to Enable/Disable data editing within the GroupBox control"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 300.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjCheckBoxPanel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjGrpControls, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTopPanel, 0, 0)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 4
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(602, 403)
            Me.mobjLayoutPanel.TabIndex = 2
            ' 
            ' mobjCheckBoxPanel
            ' 
            Me.mobjCheckBoxPanel.Controls.Add(Me.mobjChkEnable)
            Me.mobjCheckBoxPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCheckBoxPanel.Location = New System.Drawing.Point(151, 93)
            Me.mobjCheckBoxPanel.Name = "mobjCheckBoxPanel"
            Me.mobjCheckBoxPanel.Size = New System.Drawing.Size(300, 30)
            Me.mobjCheckBoxPanel.TabIndex = 0
            ' 
            ' mobjTopPanel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjTopPanel, 3)
            Me.mobjTopPanel.Controls.Add(Me.mobjInfoLabel)
            Me.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTopPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjTopPanel.Name = "mobjTopPanel"
            Me.mobjTopPanel.Size = New System.Drawing.Size(602, 93)
            Me.mobjTopPanel.TabIndex = 0
            ' 
            ' GroupBoxEnabled
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(602, 403)
            Me.Text = "GroupBoxEnabled"
            Me.mobjGrpControls.ResumeLayout(False)
            Me.mobjAdditionalLayoutPanel.ResumeLayout(False)
            Me.mobjSeminarPanel.ResumeLayout(False)
            Me.mobjListPanel.ResumeLayout(False)
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjCheckBoxPanel.ResumeLayout(False)
            Me.mobjTopPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjListBox As Gizmox.WebGUI.Forms.ListBox
        Private WithEvents mobjChkEnable As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjFirstRadioButton As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjSeminarCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjGrpControls As Gizmox.WebGUI.Forms.GroupBox
        Private WithEvents mobjClassLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjNameLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjSecondRadioButton As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private WithEvents mobjCheckBoxPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjTopPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjAdditionalLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjSeminarPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjListPanel As Gizmox.WebGUI.Forms.Panel


	End Class

End Namespace