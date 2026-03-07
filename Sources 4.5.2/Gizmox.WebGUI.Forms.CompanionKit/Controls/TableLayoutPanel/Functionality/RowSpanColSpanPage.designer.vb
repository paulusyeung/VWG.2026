Namespace CompanionKit.Controls.TableLayoutPanel.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class RowSpanColSpanPage
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
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjPanel1 = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjPanel2 = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjPanel3 = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjPanel4 = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjPanel5 = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjPanel6 = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjGroupBox.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPanel1, 0, 0)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPanel2, 2, 0)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPanel3, 0, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPanel4, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPanel5, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPanel6, 1, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(3, 17)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 4
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(590, 192)
            Me.mobjLayoutPanel.TabIndex = 0
            ' 
            ' mobjPanel1
            ' 
            Me.mobjPanel1.BackColor = System.Drawing.Color.Red
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjPanel1, 2)
            Me.mobjPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel1.Location = New System.Drawing.Point(3, 3)
            Me.mobjPanel1.Name = "mobjPanel1"
            Me.mobjPanel1.Size = New System.Drawing.Size(348, 61)
            Me.mobjPanel1.TabIndex = 0
            ' 
            ' mobjPanel2
            ' 
            Me.mobjPanel2.BackColor = System.Drawing.Color.Yellow
            Me.mobjPanel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel2.Location = New System.Drawing.Point(357, 3)
            Me.mobjPanel2.Name = "mobjPanel2"
            Me.mobjLayoutPanel.SetRowSpan(Me.mobjPanel2, 2)
            Me.mobjPanel2.Size = New System.Drawing.Size(230, 128)
            Me.mobjPanel2.TabIndex = 0
            ' 
            ' mobjPanel3
            ' 
            Me.mobjPanel3.BackColor = System.Drawing.Color.Orange
            Me.mobjPanel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel3.Location = New System.Drawing.Point(3, 70)
            Me.mobjPanel3.Name = "mobjPanel3"
            Me.mobjLayoutPanel.SetRowSpan(Me.mobjPanel3, 3)
            Me.mobjPanel3.Size = New System.Drawing.Size(171, 119)
            Me.mobjPanel3.TabIndex = 0
            ' 
            ' mobjPanel4
            ' 
            Me.mobjPanel4.BackColor = System.Drawing.Color.PowderBlue
            Me.mobjPanel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel4.Location = New System.Drawing.Point(180, 70)
            Me.mobjPanel4.Name = "mobjPanel4"
            Me.mobjPanel4.Size = New System.Drawing.Size(171, 61)
            Me.mobjPanel4.TabIndex = 0
            ' 
            ' mobjPanel5
            ' 
            Me.mobjPanel5.BackColor = System.Drawing.Color.Magenta
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjPanel5, 2)
            Me.mobjPanel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel5.Location = New System.Drawing.Point(180, 137)
            Me.mobjPanel5.Name = "mobjPanel5"
            Me.mobjPanel5.Size = New System.Drawing.Size(407, 22)
            Me.mobjPanel5.TabIndex = 0
            ' 
            ' mobjPanel6
            ' 
            Me.mobjPanel6.BackColor = System.Drawing.Color.Gray
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjPanel6, 2)
            Me.mobjPanel6.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel6.Location = New System.Drawing.Point(180, 165)
            Me.mobjPanel6.Name = "mobjPanel6"
            Me.mobjPanel6.Size = New System.Drawing.Size(407, 24)
            Me.mobjPanel6.TabIndex = 0
            ' 
            ' mobjGroupBox
            ' 
            Me.mobjGroupBox.Controls.Add(Me.mobjLayoutPanel)
            Me.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGroupBox.Location = New System.Drawing.Point(0, 0)
            Me.mobjGroupBox.Name = "mobjGroupBox"
            Me.mobjGroupBox.Size = New System.Drawing.Size(596, 212)
            Me.mobjGroupBox.TabIndex = 1
            Me.mobjGroupBox.TabStop = False
            Me.mobjGroupBox.Text = "ColumnSpan and RowSpan."
            ' 
            ' RowSpanColSpanPage
            ' 
            Me.Controls.Add(Me.mobjGroupBox)
            Me.Size = New System.Drawing.Size(596, 212)
            Me.Text = "RowSpanColSpanPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjGroupBox.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjPanel1 As Gizmox.WebGUI.Forms.Panel
        Private mobjPanel2 As Gizmox.WebGUI.Forms.Panel
        Private mobjPanel3 As Gizmox.WebGUI.Forms.Panel
        Private mobjPanel4 As Gizmox.WebGUI.Forms.Panel
        Private mobjPanel5 As Gizmox.WebGUI.Forms.Panel
        Private mobjPanel6 As Gizmox.WebGUI.Forms.Panel
        Private mobjGroupBox As Gizmox.WebGUI.Forms.GroupBox

	End Class

End Namespace
