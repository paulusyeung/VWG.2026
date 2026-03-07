Namespace CompanionKit.Controls.CheckBox.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class AutoCheckPage
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
            Me.mobjChkApprove = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjMinScore = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjTxtScore = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjLbl1 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLbl2 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjSetAutoCheck = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            CType(Me.mobjMinScore, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjChkApprove
            '
            Me.mobjChkApprove.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjChkApprove.AutoCheck = False
            Me.mobjTLP.SetColumnSpan(Me.mobjChkApprove, 2)
            Me.mobjChkApprove.Location = New System.Drawing.Point(35, 80)
            Me.mobjChkApprove.Name = "mobjChkApprove"
            Me.mobjChkApprove.Size = New System.Drawing.Size(250, 50)
            Me.mobjChkApprove.TabIndex = 1
            Me.mobjChkApprove.Text = "Approve the loan [auto check - False]"
            Me.mobjChkApprove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.mobjChkApprove.UseVisualStyleBackColor = True
            '
            'mobjMinScore
            '
            Me.mobjMinScore.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjMinScore.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjMinScore.CurrentValue = New Decimal(New Integer() {6, 0, 0, 0})
            Me.mobjMinScore.Location = New System.Drawing.Point(170, 304)
            Me.mobjMinScore.Margin = New Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0)
            Me.mobjMinScore.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
            Me.mobjMinScore.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjMinScore.Minimum = New Decimal(New Integer() {4, 0, 0, 0})
            Me.mobjMinScore.Name = "numericUpDown1"
            Me.mobjMinScore.Size = New System.Drawing.Size(140, 21)
            Me.mobjMinScore.TabIndex = 2
            Me.mobjMinScore.Value = New Decimal(New Integer() {6, 0, 0, 0})
            '
            'mobjTxtScore
            '
            Me.mobjTxtScore.AllowDrag = False
            Me.mobjTxtScore.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjTxtScore.Location = New System.Drawing.Point(170, 232)
            Me.mobjTxtScore.Margin = New Gizmox.WebGUI.Forms.Padding(10, 3, 10, 3)
            Me.mobjTxtScore.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjTxtScore.Name = "textBox1"
            Me.mobjTxtScore.ReadOnly = True
            Me.mobjTxtScore.Size = New System.Drawing.Size(140, 25)
            Me.mobjTxtScore.TabIndex = 3
            Me.mobjTxtScore.Text = "5"
            '
            'mobjLbl1
            '
            Me.mobjLbl1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLbl1.Location = New System.Drawing.Point(0, 210)
            Me.mobjLbl1.Name = "mobjLbl1"
            Me.mobjLbl1.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjLbl1.Size = New System.Drawing.Size(160, 70)
            Me.mobjLbl1.TabIndex = 4
            Me.mobjLbl1.Text = "Credit history score"
            Me.mobjLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjLbl2
            '
            Me.mobjLbl2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLbl2.Location = New System.Drawing.Point(0, 280)
            Me.mobjLbl2.Name = "mobjLbl2"
            Me.mobjLbl2.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjLbl2.Size = New System.Drawing.Size(160, 70)
            Me.mobjLbl2.TabIndex = 4
            Me.mobjLbl2.Text = "Minimal score"
            Me.mobjLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjSetAutoCheck
            '
            Me.mobjSetAutoCheck.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjTLP.SetColumnSpan(Me.mobjSetAutoCheck, 2)
            Me.mobjSetAutoCheck.Location = New System.Drawing.Point(75, 150)
            Me.mobjSetAutoCheck.Name = "mobjSetAutoCheck"
            Me.mobjSetAutoCheck.Size = New System.Drawing.Size(170, 50)
            Me.mobjSetAutoCheck.TabIndex = 5
            Me.mobjSetAutoCheck.Text = "Toggle auto check"
            Me.mobjSetAutoCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.mobjSetAutoCheck.UseVisualStyleBackColor = True
            '
            'mobjInfoLabel
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjInfoLabel, 2)
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 70)
            Me.mobjInfoLabel.TabIndex = 1
            Me.mobjInfoLabel.Text = "CheckBox with changing AutoCheck property:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjMinScore, 1, 4)
            Me.mobjTLP.Controls.Add(Me.mobjTxtScore, 1, 3)
            Me.mobjTLP.Controls.Add(Me.mobjLbl2, 0, 4)
            Me.mobjTLP.Controls.Add(Me.mobjSetAutoCheck, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjLbl1, 0, 3)
            Me.mobjTLP.Controls.Add(Me.mobjChkApprove, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 5
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 350)
            Me.mobjTLP.TabIndex = 6
            '
            'AutoCheckPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 350)
            Me.Text = "Form1"
            CType(Me.mobjMinScore, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjChkApprove As Gizmox.WebGUI.Forms.CheckBox
        Friend WithEvents mobjMinScore As Gizmox.WebGUI.Forms.NumericUpDown
        Friend WithEvents mobjTxtScore As Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents mobjLbl1 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjLbl2 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjSetAutoCheck As Gizmox.WebGUI.Forms.CheckBox
        Friend WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
