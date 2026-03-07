Namespace CompanionKit.Controls.TabControl.Appearance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ExpandCollapsePage
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
            Me.mobjTabControl = New Gizmox.WebGUI.Forms.TabControl()
            Me.mobjTabPage1 = New Gizmox.WebGUI.Forms.TabPage()
            Me.mobjTabPage2 = New Gizmox.WebGUI.Forms.TabPage()
            Me.mobjTabPage3 = New Gizmox.WebGUI.Forms.TabPage()
            Me.mobjStateLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            DirectCast(Me.mobjTabControl, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjTabControl.SuspendLayout()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjTabControl
            ' 
            Me.mobjTabControl.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray)
            Me.mobjTabControl.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjTabControl.Controls.Add(Me.mobjTabPage1)
            Me.mobjTabControl.Controls.Add(Me.mobjTabPage2)
            Me.mobjTabControl.Controls.Add(Me.mobjTabPage3)
            Me.mobjTabControl.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjTabControl.Location = New System.Drawing.Point(85, 19)
            Me.mobjTabControl.Name = "mobjTabControl"
            Me.mobjTabControl.SelectedIndex = 0
            Me.mobjTabControl.ShowExpandButton = True
            Me.mobjTabControl.Size = New System.Drawing.Size(429, 151)
            Me.mobjTabControl.TabIndex = 0
            ' 
            ' mobjTabPage1
            ' 
            Me.mobjTabPage1.BackColor = System.Drawing.Color.MediumPurple
            Me.mobjTabPage1.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray)
            Me.mobjTabPage1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjTabPage1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTabPage1.Location = New System.Drawing.Point(4, 22)
            Me.mobjTabPage1.Name = "mobjTabPage1"
            Me.mobjTabPage1.Size = New System.Drawing.Size(421, 125)
            Me.mobjTabPage1.TabIndex = 0
            Me.mobjTabPage1.Text = "tabPage1"
            ' 
            ' mobjTabPage2
            ' 
            Me.mobjTabPage2.BackColor = System.Drawing.Color.MediumPurple
            Me.mobjTabPage2.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray)
            Me.mobjTabPage2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjTabPage2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTabPage2.Location = New System.Drawing.Point(4, 22)
            Me.mobjTabPage2.Name = "mobjTabPage2"
            Me.mobjTabPage2.Size = New System.Drawing.Size(246, 125)
            Me.mobjTabPage2.TabIndex = 1
            Me.mobjTabPage2.Text = "tabPage2"
            ' 
            ' mobjTabPage3
            ' 
            Me.mobjTabPage3.BackColor = System.Drawing.Color.MediumPurple
            Me.mobjTabPage3.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray)
            Me.mobjTabPage3.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjTabPage3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTabPage3.Location = New System.Drawing.Point(0, 0)
            Me.mobjTabPage3.Name = "mobjTabPage3"
            Me.mobjTabPage3.Size = New System.Drawing.Size(421, 125)
            Me.mobjTabPage3.TabIndex = 2
            Me.mobjTabPage3.Text = "tabPage3"
            ' 
            ' mobjStateLabel
            ' 
            Me.mobjStateLabel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjStateLabel, 3)
            Me.mobjStateLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjStateLabel.Location = New System.Drawing.Point(0, 194)
            Me.mobjStateLabel.Name = "mobjStateLabel"
            Me.mobjStateLabel.Size = New System.Drawing.Size(601, 30)
            Me.mobjStateLabel.TabIndex = 2
            Me.mobjStateLabel.Text = "Now TabControl is:Expanded"
            Me.mobjStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 14.28571F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 71.42857F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 14.28571F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjTabControl, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjStateLabel, 0, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(601, 244)
            Me.mobjLayoutPanel.TabIndex = 3
            ' 
            ' ExpandCollapsePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(601, 244)
            Me.Text = "ExpandCollapse"
            DirectCast(Me.mobjTabControl, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjTabControl.ResumeLayout(False)
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjTabControl As Gizmox.WebGUI.Forms.TabControl
        Private mobjTabPage1 As Gizmox.WebGUI.Forms.TabPage
        Private mobjTabPage2 As Gizmox.WebGUI.Forms.TabPage
        Private mobjStateLabel As Gizmox.WebGUI.Forms.Label
        Private mobjTabPage3 As Gizmox.WebGUI.Forms.TabPage
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace