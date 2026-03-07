Namespace CompanionKit.Controls.UserControlFolder.ApplicationScenario

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PasswordStrengthCheckerPage
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
            Me.mobjPasswordStrengthChecker1 = New ucPasswordStrengthChecker()
            Me.mobjDescriptionLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjPasswordStrengthChecker2 = New ucPasswordStrengthChecker()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjInfoLabelPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjInfoLabelPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjPasswordStrengthChecker1
            ' 
            Me.mobjPasswordStrengthChecker1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjPasswordStrengthChecker1.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(CInt(CByte(255)), CInt(CByte(128)), CInt(CByte(0))))
            Me.mobjPasswordStrengthChecker1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjPasswordStrengthChecker1.Location = New System.Drawing.Point(0, 22)
            Me.mobjPasswordStrengthChecker1.Name = "mobjPasswordStrengthChecker1"
            Me.mobjPasswordStrengthChecker1.Size = New System.Drawing.Size(300, 75)
            Me.mobjPasswordStrengthChecker1.TabIndex = 0
            Me.mobjPasswordStrengthChecker1.Text = "ucPasswordStrengthChecker"
            ' 
            ' mobjDescriptionLabel
            ' 
            Me.mobjDescriptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDescriptionLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjDescriptionLabel.Name = "mobjDescriptionLabel"
            Me.mobjDescriptionLabel.Size = New System.Drawing.Size(512, 50)
            Me.mobjDescriptionLabel.TabIndex = 1
            Me.mobjDescriptionLabel.Text = "Use UserControl below to check password strength"
            Me.mobjDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjPasswordStrengthChecker2
            ' 
            Me.mobjPasswordStrengthChecker2.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjPasswordStrengthChecker2.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(CInt(CByte(255)), CInt(CByte(128)), CInt(CByte(0))))
            Me.mobjPasswordStrengthChecker2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjPasswordStrengthChecker2.Location = New System.Drawing.Point(96, 81)
            Me.mobjPasswordStrengthChecker2.Name = "mobjPasswordStrengthChecker2"
            Me.mobjPasswordStrengthChecker2.Size = New System.Drawing.Size(315, 118)
            Me.mobjPasswordStrengthChecker2.TabIndex = 0
            Me.mobjPasswordStrengthChecker2.Text = "ucPasswordStrengthChecker"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 320.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPasswordStrengthChecker2, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjInfoLabelPanel, 0, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 4
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 120.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(512, 232)
            Me.mobjLayoutPanel.TabIndex = 2
            ' 
            ' mobjInfoLabelPanel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjInfoLabelPanel, 3)
            Me.mobjInfoLabelPanel.Controls.Add(Me.mobjDescriptionLabel)
            Me.mobjInfoLabelPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabelPanel.Location = New System.Drawing.Point(0, 31)
            Me.mobjInfoLabelPanel.Name = "mobjInfoLabelPanel"
            Me.mobjInfoLabelPanel.Size = New System.Drawing.Size(512, 50)
            Me.mobjInfoLabelPanel.TabIndex = 0
            ' 
            ' PasswordStrengthCheckerPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(512, 232)
            Me.Text = "PasswordStrengthCheckerPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjInfoLabelPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjPasswordStrengthChecker1 As ucPasswordStrengthChecker
        Private mobjDescriptionLabel As Gizmox.WebGUI.Forms.Label
        Private mobjPasswordStrengthChecker2 As ucPasswordStrengthChecker
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjInfoLabelPanel As Gizmox.WebGUI.Forms.Panel


    End Class

End Namespace