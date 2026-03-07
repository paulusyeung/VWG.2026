Namespace CompanionKit.Controls.MaskedTextBox.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class HidePromptOnLeavePage
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
            Me.demoMaskedTextBox = New Gizmox.WebGUI.Forms.MaskedTextBox()
            Me.mobjLabel1 = New Gizmox.WebGUI.Forms.Label()
            Me.hidePromptOnLeaveCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjLabel2 = New Gizmox.WebGUI.Forms.Label()
            Me.demoMaskedTextBox2 = New Gizmox.WebGUI.Forms.MaskedTextBox()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'demoMaskedTextBox
            '
            Me.demoMaskedTextBox.AllowDrag = False
            Me.demoMaskedTextBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.demoMaskedTextBox.CustomStyle = "Masked"
            Me.demoMaskedTextBox.Location = New System.Drawing.Point(163, 177)
            Me.demoMaskedTextBox.Mask = "00/00/0000 90:00"
            Me.demoMaskedTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.demoMaskedTextBox.Name = "demoMaskedTextBox"
            Me.demoMaskedTextBox.Size = New System.Drawing.Size(154, 25)
            Me.demoMaskedTextBox.TabIndex = 2
            '
            'mobjLabel1
            '
            Me.mobjLabel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel1.Location = New System.Drawing.Point(0, 120)
            Me.mobjLabel1.Name = "mobjLabel1"
            Me.mobjLabel1.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjLabel1.Size = New System.Drawing.Size(160, 140)
            Me.mobjLabel1.TabIndex = 1
            Me.mobjLabel1.Text = "Enter text [1]"
            Me.mobjLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'hidePromptOnLeaveCheckBox
            '
            Me.hidePromptOnLeaveCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjTLP.SetColumnSpan(Me.hidePromptOnLeaveCheckBox, 2)
            Me.hidePromptOnLeaveCheckBox.Location = New System.Drawing.Point(75, 35)
            Me.hidePromptOnLeaveCheckBox.Name = "hidePromptOnLeaveCheckBox"
            Me.hidePromptOnLeaveCheckBox.Size = New System.Drawing.Size(170, 50)
            Me.hidePromptOnLeaveCheckBox.TabIndex = 0
            Me.hidePromptOnLeaveCheckBox.Text = "Hide prompt on leave"
            Me.hidePromptOnLeaveCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.hidePromptOnLeaveCheckBox.UseVisualStyleBackColor = True
            '
            'mobjLabel2
            '
            Me.mobjLabel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel2.Location = New System.Drawing.Point(0, 260)
            Me.mobjLabel2.Name = "mobjLabel2"
            Me.mobjLabel2.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjLabel2.Size = New System.Drawing.Size(160, 140)
            Me.mobjLabel2.TabIndex = 3
            Me.mobjLabel2.Text = "Enter text [2]"
            Me.mobjLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'demoMaskedTextBox2
            '
            Me.demoMaskedTextBox2.AllowDrag = False
            Me.demoMaskedTextBox2.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.demoMaskedTextBox2.CustomStyle = "Masked"
            Me.demoMaskedTextBox2.Location = New System.Drawing.Point(163, 317)
            Me.demoMaskedTextBox2.Mask = "00/00/0000 90:00"
            Me.demoMaskedTextBox2.MaximumSize = New System.Drawing.Size(200, 0)
            Me.demoMaskedTextBox2.Name = "demoMaskedTextBox2"
            Me.demoMaskedTextBox2.Size = New System.Drawing.Size(154, 25)
            Me.demoMaskedTextBox2.TabIndex = 4
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.hidePromptOnLeaveCheckBox, 0, 0)
            Me.mobjTLP.Controls.Add(Me.demoMaskedTextBox2, 1, 2)
            Me.mobjTLP.Controls.Add(Me.mobjLabel1, 0, 1)
            Me.mobjTLP.Controls.Add(Me.demoMaskedTextBox, 1, 1)
            Me.mobjTLP.Controls.Add(Me.mobjLabel2, 0, 2)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 3
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 5
            '
            'HidePromptOnLeavePage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "HidePromptOnLeavePage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents demoMaskedTextBox As Gizmox.WebGUI.Forms.MaskedTextBox
        Friend WithEvents mobjLabel1 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents hidePromptOnLeaveCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Friend WithEvents mobjLabel2 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents demoMaskedTextBox2 As Gizmox.WebGUI.Forms.MaskedTextBox
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel
	End Class

End Namespace