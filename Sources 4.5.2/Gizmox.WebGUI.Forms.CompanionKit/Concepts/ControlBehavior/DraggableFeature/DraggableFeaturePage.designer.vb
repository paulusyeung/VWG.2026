Namespace CompanionKit.Concepts.ControlBehavior.DraggableFeature

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class DraggableFeaturePage
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
            Me.mobjButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjTargetPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjRevertModeComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjRevertLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjSnapModeComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjSnapModeLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjSnapToLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjSnapToComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjContainerPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjTargetPanel.SuspendLayout()
            Me.mobjGroupBox.SuspendLayout()
            Me.mobjContainerPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjButton
            ' 
            Me.mobjButton.AccessibleDescription = ""
            Me.mobjButton.AccessibleName = ""
            Me.mobjButton.Draggable = New Gizmox.WebGUI.Forms.DraggableOptions(True)
            Me.mobjButton.Location = New System.Drawing.Point(38, 67)
            Me.mobjButton.Name = "mobjButton"
            Me.mobjButton.Size = New System.Drawing.Size(100, 100)
            Me.mobjButton.TabIndex = 2
            Me.mobjButton.Text = "Draggable Button"
            ' 
            ' mobjTargetPanel
            ' 
            Me.mobjTargetPanel.AccessibleDescription = ""
            Me.mobjTargetPanel.AccessibleName = ""
            Me.mobjTargetPanel.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Red)
            Me.mobjTargetPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjTargetPanel.BorderWidth = New Gizmox.WebGUI.Forms.BorderWidth(2)
            Me.mobjTargetPanel.Controls.Add(Me.mobjLabel)
            Me.mobjTargetPanel.Location = New System.Drawing.Point(297, 66)
            Me.mobjTargetPanel.Name = "mobjTargetPanel"
            Me.mobjTargetPanel.Size = New System.Drawing.Size(102, 102)
            Me.mobjTargetPanel.TabIndex = 1
            ' 
            ' mobjLabel
            ' 
            Me.mobjLabel.AccessibleDescription = ""
            Me.mobjLabel.AccessibleName = ""
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(100, 100)
            Me.mobjLabel.TabIndex = 0
            Me.mobjLabel.Text = "Drag here"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjCheckBox
            ' 
            Me.mobjCheckBox.AccessibleDescription = ""
            Me.mobjCheckBox.AccessibleName = ""
            Me.mobjCheckBox.AutoSize = True
            Me.mobjCheckBox.Checked = True
            Me.mobjCheckBox.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjCheckBox.Location = New System.Drawing.Point(23, 33)
            Me.mobjCheckBox.Name = "mobjCheckBox"
            Me.mobjCheckBox.Size = New System.Drawing.Size(124, 17)
            Me.mobjCheckBox.TabIndex = 3
            Me.mobjCheckBox.Text = "Allow to drag button"
            ' 
            ' mobjGroupBox
            ' 
            Me.mobjGroupBox.AccessibleDescription = ""
            Me.mobjGroupBox.AccessibleName = ""
            Me.mobjGroupBox.Controls.Add(Me.mobjRevertModeComboBox)
            Me.mobjGroupBox.Controls.Add(Me.mobjRevertLabel)
            Me.mobjGroupBox.Controls.Add(Me.mobjSnapModeComboBox)
            Me.mobjGroupBox.Controls.Add(Me.mobjSnapModeLabel)
            Me.mobjGroupBox.Controls.Add(Me.mobjSnapToLabel)
            Me.mobjGroupBox.Controls.Add(Me.mobjSnapToComboBox)
            Me.mobjGroupBox.Controls.Add(Me.mobjCheckBox)
            Me.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGroupBox.Location = New System.Drawing.Point(15, 179)
            Me.mobjGroupBox.Name = "mobjGroupBox"
            Me.mobjGroupBox.Size = New System.Drawing.Size(413, 160)
            Me.mobjGroupBox.TabIndex = 4
            Me.mobjGroupBox.TabStop = False
            Me.mobjGroupBox.Text = "Options"
            ' 
            ' mobjRevertModeComboBox
            ' 
            Me.mobjRevertModeComboBox.AccessibleDescription = ""
            Me.mobjRevertModeComboBox.AccessibleName = ""
            Me.mobjRevertModeComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjRevertModeComboBox.FormattingEnabled = True
            Me.mobjRevertModeComboBox.Items.AddRange(New Object() {"None", "Always", "Invalid", "Valid"})
            Me.mobjRevertModeComboBox.Location = New System.Drawing.Point(152, 60)
            Me.mobjRevertModeComboBox.Name = "mobjRevertModeComboBox"
            Me.mobjRevertModeComboBox.Size = New System.Drawing.Size(100, 21)
            Me.mobjRevertModeComboBox.TabIndex = 5
            Me.mobjRevertModeComboBox.Text = "None"
            ' 
            ' mobjRevertLabel
            ' 
            Me.mobjRevertLabel.AccessibleDescription = ""
            Me.mobjRevertLabel.AccessibleName = ""
            Me.mobjRevertLabel.AutoSize = True
            Me.mobjRevertLabel.Location = New System.Drawing.Point(20, 63)
            Me.mobjRevertLabel.Name = "mobjRevertLabel"
            Me.mobjRevertLabel.Size = New System.Drawing.Size(35, 13)
            Me.mobjRevertLabel.TabIndex = 7
            Me.mobjRevertLabel.Text = "RevertMode"
            ' 
            ' mobjSnapModeComboBox
            ' 
            Me.mobjSnapModeComboBox.AccessibleDescription = ""
            Me.mobjSnapModeComboBox.AccessibleName = ""
            Me.mobjSnapModeComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjSnapModeComboBox.FormattingEnabled = True
            Me.mobjSnapModeComboBox.Items.AddRange(New Object() {"Both", "Inner", "Outer"})
            Me.mobjSnapModeComboBox.Location = New System.Drawing.Point(152, 92)
            Me.mobjSnapModeComboBox.Name = "mobjSnapModeComboBox"
            Me.mobjSnapModeComboBox.Size = New System.Drawing.Size(100, 21)
            Me.mobjSnapModeComboBox.TabIndex = 9
            Me.mobjSnapModeComboBox.Text = "Both"
            ' 
            ' mobjSnapModeLabel
            ' 
            Me.mobjSnapModeLabel.AccessibleDescription = ""
            Me.mobjSnapModeLabel.AccessibleName = ""
            Me.mobjSnapModeLabel.AutoSize = True
            Me.mobjSnapModeLabel.Location = New System.Drawing.Point(20, 95)
            Me.mobjSnapModeLabel.Name = "mobjSnapModeLabel"
            Me.mobjSnapModeLabel.Size = New System.Drawing.Size(35, 13)
            Me.mobjSnapModeLabel.TabIndex = 10
            Me.mobjSnapModeLabel.Text = "SnapMode"
            ' 
            ' mobjSnapToLabel
            ' 
            Me.mobjSnapToLabel.AccessibleDescription = ""
            Me.mobjSnapToLabel.AccessibleName = ""
            Me.mobjSnapToLabel.AutoSize = True
            Me.mobjSnapToLabel.Location = New System.Drawing.Point(20, 125)
            Me.mobjSnapToLabel.Name = "mobjSnapToLabel"
            Me.mobjSnapToLabel.Size = New System.Drawing.Size(35, 13)
            Me.mobjSnapToLabel.TabIndex = 11
            Me.mobjSnapToLabel.Text = "SnapTo"
            ' 
            ' mobjSnapToComboBox
            ' 
            Me.mobjSnapToComboBox.AccessibleDescription = ""
            Me.mobjSnapToComboBox.AccessibleName = ""
            Me.mobjSnapToComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjSnapToComboBox.FormattingEnabled = True
            Me.mobjSnapToComboBox.Items.AddRange(New Object() {"None", "All", "Siblings"})
            Me.mobjSnapToComboBox.Location = New System.Drawing.Point(152, 125)
            Me.mobjSnapToComboBox.Name = "mobjSnapToComboBox"
            Me.mobjSnapToComboBox.Size = New System.Drawing.Size(100, 21)
            Me.mobjSnapToComboBox.TabIndex = 13
            Me.mobjSnapToComboBox.Text = "None"
            ' 
            ' mobjContainerPanel
            ' 
            Me.mobjContainerPanel.AccessibleDescription = ""
            Me.mobjContainerPanel.AccessibleName = ""
            Me.mobjContainerPanel.Controls.Add(Me.mobjButton)
            Me.mobjContainerPanel.Controls.Add(Me.mobjGroupBox)
            Me.mobjContainerPanel.Controls.Add(Me.mobjTargetPanel)
            Me.mobjContainerPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjContainerPanel.DockPadding.Bottom = 15
            Me.mobjContainerPanel.DockPadding.Left = 15
            Me.mobjContainerPanel.DockPadding.Right = 15
            Me.mobjContainerPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjContainerPanel.Name = "mobjContainerPanel"
            Me.mobjContainerPanel.Padding = New Gizmox.WebGUI.Forms.Padding(15, 0, 15, 15)
            Me.mobjContainerPanel.Size = New System.Drawing.Size(443, 354)
            Me.mobjContainerPanel.TabIndex = 5
            ' 
            ' DraggableFeaturePage
            ' 
            Me.Controls.Add(Me.mobjContainerPanel)
            Me.MaximumSize = New System.Drawing.Size(1000, 0)
            Me.Size = New System.Drawing.Size(443, 354)
            Me.Text = "DraggableFeaturePage"
            Me.mobjTargetPanel.ResumeLayout(False)
            Me.mobjGroupBox.ResumeLayout(False)
            Me.mobjContainerPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjTargetPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private mobjGroupBox As Gizmox.WebGUI.Forms.GroupBox
        Private WithEvents mobjRevertModeComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjRevertLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjSnapModeComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjSnapModeLabel As Gizmox.WebGUI.Forms.Label
        Private mobjSnapToLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjSnapToComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjContainerPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace