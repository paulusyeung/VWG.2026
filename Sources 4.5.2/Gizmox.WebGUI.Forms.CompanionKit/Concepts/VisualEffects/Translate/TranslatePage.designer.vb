Namespace CompanionKit.Concepts.VisualEffects.Translate

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class TranslatePage
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
            Me.mobjToggleButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjSecondTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjFirstTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjDirectionGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjHorizontalCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjVerticalCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjBottomPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjTopPanel.SuspendLayout()
            Me.mobjSecondTopPanel.SuspendLayout()
            Me.mobjFirstTopPanel.SuspendLayout()
            Me.mobjDirectionGroupBox.SuspendLayout()
            Me.mobjBottomPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjApplyButton
            ' 
            Me.mobjToggleButton.AccessibleDescription = ""
            Me.mobjToggleButton.AccessibleName = ""
            Me.mobjToggleButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjToggleButton.Location = New System.Drawing.Point(30, 10)
            Me.mobjToggleButton.Name = "mobjApplyButton"
            Me.mobjToggleButton.Size = New System.Drawing.Size(223, 41)
            Me.mobjToggleButton.TabIndex = 14
            Me.mobjToggleButton.Text = "Apply Translate Visual Effect"
            ' 
            ' objTopPanel
            ' 
            Me.mobjTopPanel.AccessibleDescription = ""
            Me.mobjTopPanel.AccessibleName = ""
            Me.mobjTopPanel.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Transparent)
            Me.mobjTopPanel.Controls.Add(Me.mobjSecondTopPanel)
            Me.mobjTopPanel.Controls.Add(Me.mobjFirstTopPanel)
            Me.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjTopPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjTopPanel.Name = "objTopPanel"
            Me.mobjTopPanel.Size = New System.Drawing.Size(283, 163)
            Me.mobjTopPanel.TabIndex = 0
            ' 
            ' mobjSecondTopPanel
            ' 
            Me.mobjSecondTopPanel.AccessibleDescription = ""
            Me.mobjSecondTopPanel.AccessibleName = ""
            Me.mobjSecondTopPanel.Controls.Add(Me.mobjToggleButton)
            Me.mobjSecondTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSecondTopPanel.DockPadding.Bottom = 10
            Me.mobjSecondTopPanel.DockPadding.Left = 30
            Me.mobjSecondTopPanel.DockPadding.Right = 30
            Me.mobjSecondTopPanel.DockPadding.Top = 10
            Me.mobjSecondTopPanel.Location = New System.Drawing.Point(0, 102)
            Me.mobjSecondTopPanel.Name = "mobjSecondTopPanel"
            Me.mobjSecondTopPanel.Padding = New Gizmox.WebGUI.Forms.Padding(30, 10, 30, 10)
            Me.mobjSecondTopPanel.Size = New System.Drawing.Size(283, 61)
            Me.mobjSecondTopPanel.TabIndex = 16
            ' 
            ' mobjFirstTopPanel
            ' 
            Me.mobjFirstTopPanel.AccessibleDescription = ""
            Me.mobjFirstTopPanel.AccessibleName = ""
            Me.mobjFirstTopPanel.Controls.Add(Me.mobjDirectionGroupBox)
            Me.mobjFirstTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjFirstTopPanel.DockPadding.Bottom = 15
            Me.mobjFirstTopPanel.DockPadding.Left = 30
            Me.mobjFirstTopPanel.DockPadding.Top = 15
            Me.mobjFirstTopPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjFirstTopPanel.Name = "mobjFirstTopPanel"
            Me.mobjFirstTopPanel.Padding = New Gizmox.WebGUI.Forms.Padding(30, 15, 0, 15)
            Me.mobjFirstTopPanel.Size = New System.Drawing.Size(283, 102)
            Me.mobjFirstTopPanel.TabIndex = 15
            ' 
            ' mobjDirectionGroupBox
            ' 
            Me.mobjDirectionGroupBox.AccessibleDescription = ""
            Me.mobjDirectionGroupBox.AccessibleName = ""
            Me.mobjDirectionGroupBox.Controls.Add(Me.mobjHorizontalCheckBox)
            Me.mobjDirectionGroupBox.Controls.Add(Me.mobjVerticalCheckBox)
            Me.mobjDirectionGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjDirectionGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjDirectionGroupBox.Location = New System.Drawing.Point(30, 15)
            Me.mobjDirectionGroupBox.Name = "mobjDirectionGroupBox"
            Me.mobjDirectionGroupBox.Size = New System.Drawing.Size(152, 72)
            Me.mobjDirectionGroupBox.TabIndex = 2
            Me.mobjDirectionGroupBox.TabStop = False
            Me.mobjDirectionGroupBox.Text = "Direction"
            ' 
            ' mobjHorizontalCheckBox
            ' 
            Me.mobjHorizontalCheckBox.AccessibleDescription = ""
            Me.mobjHorizontalCheckBox.AccessibleName = ""
            Me.mobjHorizontalCheckBox.AutoSize = True
            Me.mobjHorizontalCheckBox.Location = New System.Drawing.Point(32, 21)
            Me.mobjHorizontalCheckBox.Name = "objHorizontalCheckBox"
            Me.mobjHorizontalCheckBox.Size = New System.Drawing.Size(74, 17)
            Me.mobjHorizontalCheckBox.TabIndex = 15
            Me.mobjHorizontalCheckBox.Text = "Horizontal"
            ' 
            ' mobjVerticalCheckBox
            ' 
            Me.mobjVerticalCheckBox.AccessibleDescription = ""
            Me.mobjVerticalCheckBox.AccessibleName = ""
            Me.mobjVerticalCheckBox.AutoSize = True
            Me.mobjVerticalCheckBox.Location = New System.Drawing.Point(32, 47)
            Me.mobjVerticalCheckBox.Name = "objVerticalCheckBox"
            Me.mobjVerticalCheckBox.Size = New System.Drawing.Size(61, 17)
            Me.mobjVerticalCheckBox.TabIndex = 16
            Me.mobjVerticalCheckBox.Text = "Vertical"
            ' 
            ' mobjPanel
            ' 
            Me.mobjPanel.AccessibleDescription = ""
            Me.mobjPanel.AccessibleName = ""
            Me.mobjPanel.BackColor = System.Drawing.Color.Silver
            Me.mobjPanel.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(CInt(CByte(64)), CInt(CByte(64)), CInt(CByte(64))))
            Me.mobjPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjPanel.BorderWidth = New Gizmox.WebGUI.Forms.BorderWidth(2)
            Me.mobjPanel.Location = New System.Drawing.Point(20, 20)
            Me.mobjPanel.Name = "objPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(80, 80)
            Me.mobjPanel.TabIndex = 1
            ' 
            ' mobjBottomPanel
            ' 
            Me.mobjBottomPanel.AccessibleDescription = ""
            Me.mobjBottomPanel.AccessibleName = ""
            Me.mobjBottomPanel.Controls.Add(Me.mobjPanel)
            Me.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjBottomPanel.Location = New System.Drawing.Point(0, 163)
            Me.mobjBottomPanel.Name = "objBottomPanel"
            Me.mobjBottomPanel.Size = New System.Drawing.Size(283, 233)
            Me.mobjBottomPanel.TabIndex = 2
            ' 
            ' TranslatePage
            ' 
            Me.Controls.Add(Me.mobjBottomPanel)
            Me.Controls.Add(Me.mobjTopPanel)
            Me.Size = New System.Drawing.Size(283, 396)
            Me.Text = "TranslatePage"
            Me.mobjTopPanel.ResumeLayout(False)
            Me.mobjSecondTopPanel.ResumeLayout(False)
            Me.mobjFirstTopPanel.ResumeLayout(False)
            Me.mobjDirectionGroupBox.ResumeLayout(False)
            Me.mobjBottomPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjToggleButton As Gizmox.WebGUI.Forms.Button
        Private mobjTopPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents mobjVerticalCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjHorizontalCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private mobjDirectionGroupBox As Gizmox.WebGUI.Forms.GroupBox
        Private mobjBottomPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjSecondTopPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjFirstTopPanel As Gizmox.WebGUI.Forms.Panel


	End Class

End Namespace