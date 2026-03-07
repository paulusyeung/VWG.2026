Namespace CompanionKit.Controls.TabControl.Appearance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class TabsAlignmentPage
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
            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(TabsAlignmentPage))
            Me.mobjTabControl = New Gizmox.WebGUI.Forms.TabControl()
            Me.mobjGreenTabPage = New Gizmox.WebGUI.Forms.TabPage()
            Me.mobjYellowTabPage = New Gizmox.WebGUI.Forms.TabPage()
            Me.mobjRedTabPage = New Gizmox.WebGUI.Forms.TabPage()
            Me.mobjTopRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjBottomRadioButton = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjAlignmentGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            DirectCast(Me.mobjTabControl, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjTabControl.SuspendLayout()
            Me.mobjAlignmentGroupBox.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjTabControl
            ' 
            Me.mobjTabControl.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjTabControl.Controls.Add(Me.mobjGreenTabPage)
            Me.mobjTabControl.Controls.Add(Me.mobjYellowTabPage)
            Me.mobjTabControl.Controls.Add(Me.mobjRedTabPage)
            Me.mobjTabControl.Location = New System.Drawing.Point(58, 32)
            Me.mobjTabControl.Name = "mobjTabControl"
            Me.mobjTabControl.SelectedIndex = 0
            Me.mobjTabControl.Size = New System.Drawing.Size(270, 251)
            Me.mobjTabControl.TabIndex = 0
            ' 
            ' mobjGreenTabPage
            ' 
            Me.mobjGreenTabPage.BackColor = System.Drawing.Color.FromArgb(CInt(CByte(128)), CInt(CByte(255)), CInt(CByte(128)))
            Me.mobjGreenTabPage.BackgroundImage = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjGreenTabPage.BackgroundImage"))
            Me.mobjGreenTabPage.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Stretch
            Me.mobjGreenTabPage.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGreenTabPage.Location = New System.Drawing.Point(4, 22)
            Me.mobjGreenTabPage.Name = "mobjGreenTabPage"
            Me.mobjGreenTabPage.Size = New System.Drawing.Size(262, 225)
            Me.mobjGreenTabPage.TabIndex = 0
            Me.mobjGreenTabPage.Text = "GreenTabPage"
            ' 
            ' mobjYellowTabPage
            ' 
            Me.mobjYellowTabPage.BackColor = System.Drawing.Color.FromArgb(CInt(CByte(255)), CInt(CByte(255)), CInt(CByte(128)))
            Me.mobjYellowTabPage.BackgroundImage = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjYellowTabPage.BackgroundImage"))
            Me.mobjYellowTabPage.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Stretch
            Me.mobjYellowTabPage.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjYellowTabPage.Location = New System.Drawing.Point(4, 22)
            Me.mobjYellowTabPage.Name = "mobjYellowTabPage"
            Me.mobjYellowTabPage.Size = New System.Drawing.Size(262, 225)
            Me.mobjYellowTabPage.TabIndex = 1
            Me.mobjYellowTabPage.Text = "YellowTabPage"
            ' 
            ' mobjRedTabPage
            ' 
            Me.mobjRedTabPage.BackColor = System.Drawing.Color.FromArgb(CInt(CByte(255)), CInt(CByte(128)), CInt(CByte(128)))
            Me.mobjRedTabPage.BackgroundImage = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjRedTabPage.BackgroundImage"))
            Me.mobjRedTabPage.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Stretch
            Me.mobjRedTabPage.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjRedTabPage.Location = New System.Drawing.Point(0, 0)
            Me.mobjRedTabPage.Name = "mobjRedTabPage"
            Me.mobjRedTabPage.Size = New System.Drawing.Size(262, 225)
            Me.mobjRedTabPage.TabIndex = 2
            Me.mobjRedTabPage.Text = "RedTabPage"
            ' 
            ' mobjTopRadioButton
            ' 
            Me.mobjTopRadioButton.AutoSize = True
            Me.mobjTopRadioButton.Checked = True
            Me.mobjTopRadioButton.Location = New System.Drawing.Point(40, 29)
            Me.mobjTopRadioButton.Name = "mobjTopRadioButton"
            Me.mobjTopRadioButton.Size = New System.Drawing.Size(43, 17)
            Me.mobjTopRadioButton.TabIndex = 1
            Me.mobjTopRadioButton.Text = "Top"
            ' 
            ' mobjBottomRadioButton
            ' 
            Me.mobjBottomRadioButton.AutoSize = True
            Me.mobjBottomRadioButton.Location = New System.Drawing.Point(40, 55)
            Me.mobjBottomRadioButton.Name = "mobjBottomRadioButton"
            Me.mobjBottomRadioButton.Size = New System.Drawing.Size(59, 17)
            Me.mobjBottomRadioButton.TabIndex = 2
            Me.mobjBottomRadioButton.Text = "Bottom"
            ' 
            ' mobjAlignmentGroupBox
            ' 
            Me.mobjAlignmentGroupBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjAlignmentGroupBox.Controls.Add(Me.mobjTopRadioButton)
            Me.mobjAlignmentGroupBox.Controls.Add(Me.mobjBottomRadioButton)
            Me.mobjAlignmentGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjAlignmentGroupBox.Location = New System.Drawing.Point(58, 310)
            Me.mobjAlignmentGroupBox.Name = "mobjAlignmentGroupBox"
            Me.mobjAlignmentGroupBox.Size = New System.Drawing.Size(150, 88)
            Me.mobjAlignmentGroupBox.TabIndex = 3
            Me.mobjAlignmentGroupBox.TabStop = False
            Me.mobjAlignmentGroupBox.Text = "Tabs Alignment"
            ' 
            ' TabsAlignmentPage
            ' 
            Me.Controls.Add(Me.mobjAlignmentGroupBox)
            Me.Controls.Add(Me.mobjTabControl)
            Me.Size = New System.Drawing.Size(385, 427)
            Me.Text = "TabsAlignmentPage"
            DirectCast(Me.mobjTabControl, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjTabControl.ResumeLayout(False)
            Me.mobjAlignmentGroupBox.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjTabControl As Gizmox.WebGUI.Forms.TabControl
        Private mobjGreenTabPage As Gizmox.WebGUI.Forms.TabPage
        Private mobjYellowTabPage As Gizmox.WebGUI.Forms.TabPage
        Private WithEvents mobjTopRadioButton As Gizmox.WebGUI.Forms.RadioButton
        Private mobjBottomRadioButton As Gizmox.WebGUI.Forms.RadioButton
        Private mobjAlignmentGroupBox As Gizmox.WebGUI.Forms.GroupBox
        Private mobjRedTabPage As Gizmox.WebGUI.Forms.TabPage
	End Class

End Namespace