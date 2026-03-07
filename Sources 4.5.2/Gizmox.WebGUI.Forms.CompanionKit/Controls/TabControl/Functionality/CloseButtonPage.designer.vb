Namespace CompanionKit.Controls.TabControl.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class CloseButtonPage
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
            Me.mobjDemoTabControl = New Gizmox.WebGUI.Forms.TabControl()
            Me.mobjTabPage3 = New Gizmox.WebGUI.Forms.TabPage()
            Me.mobjTabPage4 = New Gizmox.WebGUI.Forms.TabPage()
            Me.mobjTabPage5 = New Gizmox.WebGUI.Forms.TabPage()
            Me.mobjTabPage6 = New Gizmox.WebGUI.Forms.TabPage()
            Me.mobjTabPage7 = New Gizmox.WebGUI.Forms.TabPage()
            Me.mobjTabPage1 = New Gizmox.WebGUI.Forms.TabPage()
            Me.mobjTabPage2 = New Gizmox.WebGUI.Forms.TabPage()
            Me.mobjCloseButtonCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjCheckBoxPanel = New Gizmox.WebGUI.Forms.Panel()
            DirectCast(Me.mobjDemoTabControl, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjDemoTabControl.SuspendLayout()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjCheckBoxPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDemoTabControl
            ' 
            Me.mobjDemoTabControl.Controls.Add(Me.mobjTabPage3)
            Me.mobjDemoTabControl.Controls.Add(Me.mobjTabPage4)
            Me.mobjDemoTabControl.Controls.Add(Me.mobjTabPage5)
            Me.mobjDemoTabControl.Controls.Add(Me.mobjTabPage6)
            Me.mobjDemoTabControl.Controls.Add(Me.mobjTabPage7)
            Me.mobjDemoTabControl.Controls.Add(Me.mobjTabPage1)
            Me.mobjDemoTabControl.Controls.Add(Me.mobjTabPage2)
            Me.mobjDemoTabControl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDemoTabControl.Location = New System.Drawing.Point(0, 60)
            Me.mobjDemoTabControl.Name = "mobjDemoTabControl"
            Me.mobjDemoTabControl.SelectedIndex = 0
            Me.mobjDemoTabControl.ShowCloseButton = True
            Me.mobjDemoTabControl.Size = New System.Drawing.Size(391, 177)
            Me.mobjDemoTabControl.TabIndex = 0
            ' 
            ' mobjTabPage3
            ' 
            Me.mobjTabPage3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTabPage3.Location = New System.Drawing.Point(0, 0)
            Me.mobjTabPage3.Name = "mobjTabPage3"
            Me.mobjTabPage3.Size = New System.Drawing.Size(383, 150)
            Me.mobjTabPage3.TabIndex = 2
            Me.mobjTabPage3.Text = "Tab Page 3"
            ' 
            ' mobjTabPage4
            ' 
            Me.mobjTabPage4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTabPage4.Location = New System.Drawing.Point(0, 0)
            Me.mobjTabPage4.Name = "mobjTabPage4"
            Me.mobjTabPage4.Size = New System.Drawing.Size(383, 150)
            Me.mobjTabPage4.TabIndex = 3
            Me.mobjTabPage4.Text = "Tab Page 4"
            ' 
            ' mobjTabPage5
            ' 
            Me.mobjTabPage5.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTabPage5.Location = New System.Drawing.Point(0, 0)
            Me.mobjTabPage5.Name = "mobjTabPage5"
            Me.mobjTabPage5.Size = New System.Drawing.Size(383, 150)
            Me.mobjTabPage5.TabIndex = 4
            Me.mobjTabPage5.Text = "Tab Page 5"
            ' 
            ' mobjTabPage6
            ' 
            Me.mobjTabPage6.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTabPage6.Location = New System.Drawing.Point(0, 0)
            Me.mobjTabPage6.Name = "mobjTabPage6"
            Me.mobjTabPage6.Size = New System.Drawing.Size(383, 150)
            Me.mobjTabPage6.TabIndex = 5
            Me.mobjTabPage6.Text = "Tab Page 6"
            ' 
            ' mobjTabPage7
            ' 
            Me.mobjTabPage7.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTabPage7.Location = New System.Drawing.Point(4, 22)
            Me.mobjTabPage7.Name = "mobjTabPage7"
            Me.mobjTabPage7.Size = New System.Drawing.Size(383, 151)
            Me.mobjTabPage7.TabIndex = 6
            Me.mobjTabPage7.Text = "Tab Page 7"
            ' 
            ' mobjTabPage1
            ' 
            Me.mobjTabPage1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTabPage1.Location = New System.Drawing.Point(4, 23)
            Me.mobjTabPage1.Name = "mobjTabPage1"
            Me.mobjTabPage1.Size = New System.Drawing.Size(383, 150)
            Me.mobjTabPage1.TabIndex = 0
            Me.mobjTabPage1.Text = "Tab Page1"
            ' 
            ' mobjTabPage2
            ' 
            Me.mobjTabPage2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTabPage2.Location = New System.Drawing.Point(4, 22)
            Me.mobjTabPage2.Name = "mobjTabPage2"
            Me.mobjTabPage2.Size = New System.Drawing.Size(383, 150)
            Me.mobjTabPage2.TabIndex = 1
            Me.mobjTabPage2.Text = "Tab Page 2"
            ' 
            ' mobjCloseButtonCheckBox
            ' 
            Me.mobjCloseButtonCheckBox.AutoSize = True
            Me.mobjCloseButtonCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjCloseButtonCheckBox.Location = New System.Drawing.Point(10, 23)
            Me.mobjCloseButtonCheckBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjCloseButtonCheckBox.Name = "mobjCloseButtonCheckBox"
            Me.mobjCloseButtonCheckBox.Size = New System.Drawing.Size(200, 17)
            Me.mobjCloseButtonCheckBox.TabIndex = 1
            Me.mobjCloseButtonCheckBox.Text = "Show CloseButton"
            Me.mobjCloseButtonCheckBox.UseVisualStyleBackColor = True
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 1
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoTabControl, 0, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjCheckBoxPanel, 0, 0)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 10)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 3
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(391, 237)
            Me.mobjLayoutPanel.TabIndex = 2
            ' 
            ' mobjCheckBoxPanel
            ' 
            Me.mobjCheckBoxPanel.Controls.Add(Me.mobjCloseButtonCheckBox)
            Me.mobjCheckBoxPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCheckBoxPanel.DockPadding.Left = 10
            Me.mobjCheckBoxPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjCheckBoxPanel.Name = "mobjCheckBoxPanel"
            Me.mobjCheckBoxPanel.Padding = New Gizmox.WebGUI.Forms.Padding(10, 0, 0, 0)
            Me.mobjCheckBoxPanel.Size = New System.Drawing.Size(391, 40)
            Me.mobjCheckBoxPanel.TabIndex = 0
            ' 
            ' CloseButtonPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.DockPadding.Top = 10
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(0, 10, 0, 0)
            Me.Size = New System.Drawing.Size(391, 247)
            Me.Text = "CloseButtonPage"
            DirectCast(Me.mobjDemoTabControl, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjDemoTabControl.ResumeLayout(False)
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjCheckBoxPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjDemoTabControl As Gizmox.WebGUI.Forms.TabControl
        Private mobjTabPage1 As Gizmox.WebGUI.Forms.TabPage
        Private mobjTabPage2 As Gizmox.WebGUI.Forms.TabPage
        Private mobjTabPage3 As Gizmox.WebGUI.Forms.TabPage
        Private mobjTabPage4 As Gizmox.WebGUI.Forms.TabPage
        Private mobjTabPage5 As Gizmox.WebGUI.Forms.TabPage
        Private mobjTabPage6 As Gizmox.WebGUI.Forms.TabPage
        Private mobjTabPage7 As Gizmox.WebGUI.Forms.TabPage
        Private WithEvents mobjCloseButtonCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjCheckBoxPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace