Namespace CompanionKit.Controls.TableLayoutPanel.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class AddingControlPage
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
            Me.TableLayoutPanel1 = New Gizmox.WebGUI.Forms.TableLayoutPanel
            Me.Panel1 = New Gizmox.WebGUI.Forms.Panel
            Me.Panel2 = New Gizmox.WebGUI.Forms.Panel
            Me.Panel3 = New Gizmox.WebGUI.Forms.Panel
            Me.Panel4 = New Gizmox.WebGUI.Forms.Panel
            Me.Panel5 = New Gizmox.WebGUI.Forms.Panel
            Me.Panel6 = New Gizmox.WebGUI.Forms.Panel
            Me.GroupBox1 = New Gizmox.WebGUI.Forms.GroupBox
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.TableLayoutPanel1.CellBorderStyle = Gizmox.WebGUI.Forms.TableLayoutPanelCellBorderStyle.None
            Me.TableLayoutPanel1.ColumnCount = 3
            Me.TableLayoutPanel1.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 40.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 1, 3)
            Me.TableLayoutPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.GrowStyle = Gizmox.WebGUI.Forms.TableLayoutPanelGrowStyle.AddRows
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 17)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 4
            Me.TableLayoutPanel1.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(590, 192)
            Me.TableLayoutPanel1.TabIndex = 0
            '
            'Panel1
            '
            Me.Panel1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.Panel1.BackColor = System.Drawing.Color.Red
            Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
            Me.Panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.Panel1.Location = New System.Drawing.Point(3, 3)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(348, 61)
            Me.Panel1.TabIndex = 0
            '
            'Panel2
            '
            Me.Panel2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.Panel2.BackColor = System.Drawing.Color.Yellow
            Me.Panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.Panel2.Location = New System.Drawing.Point(233, 3)
            Me.Panel2.Name = "Panel2"
            Me.TableLayoutPanel1.SetRowSpan(Me.Panel2, 2)
            Me.Panel2.Size = New System.Drawing.Size(230, 128)
            Me.Panel2.TabIndex = 0
            '
            'Panel3
            '
            Me.Panel3.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.Panel3.BackColor = System.Drawing.Color.Orange
            Me.Panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.Panel3.Location = New System.Drawing.Point(3, 70)
            Me.Panel3.Name = "Panel3"
            Me.TableLayoutPanel1.SetRowSpan(Me.Panel3, 3)
            Me.Panel3.Size = New System.Drawing.Size(171, 119)
            Me.Panel3.TabIndex = 0
            '
            'Panel4
            '
            Me.Panel4.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.Panel4.BackColor = System.Drawing.Color.PowderBlue
            Me.Panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.Panel4.Location = New System.Drawing.Point(180, 70)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(171, 61)
            Me.Panel4.TabIndex = 0
            '
            'Panel5
            '
            Me.Panel5.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.Panel5.BackColor = System.Drawing.Color.Magenta
            Me.TableLayoutPanel1.SetColumnSpan(Me.Panel5, 2)
            Me.Panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.Panel5.Location = New System.Drawing.Point(180, 137)
            Me.Panel5.Name = "Panel5"
            Me.Panel5.Size = New System.Drawing.Size(264, 28)
            Me.Panel5.TabIndex = 0
            '
            'Panel6
            '
            Me.Panel6.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.Panel6.BackColor = System.Drawing.Color.Gray
            Me.TableLayoutPanel1.SetColumnSpan(Me.Panel6, 2)
            Me.Panel6.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.Panel6.Location = New System.Drawing.Point(180, 165)
            Me.Panel6.Name = "Panel6"
            Me.Panel6.Size = New System.Drawing.Size(264, 31)
            Me.Panel6.TabIndex = 0
            '
            'GroupBox1
            '
            Me.GroupBox1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
            Me.GroupBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.GroupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(596, 212)
            Me.GroupBox1.TabIndex = 1
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "TableLayoutPanel with panels"
            '
            'AddingControlPage
            '
            Me.Controls.Add(Me.GroupBox1)
            Me.Size = New System.Drawing.Size(596, 212)
            Me.Text = "AddingControlPage"
            Me.GroupBox1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
		Friend WithEvents TableLayoutPanel1 As Gizmox.WebGUI.Forms.TableLayoutPanel
		Friend WithEvents Panel1 As Gizmox.WebGUI.Forms.Panel
		Friend WithEvents Panel2 As Gizmox.WebGUI.Forms.Panel
		Friend WithEvents Panel3 As Gizmox.WebGUI.Forms.Panel
		Friend WithEvents Panel4 As Gizmox.WebGUI.Forms.Panel
		Friend WithEvents Panel5 As Gizmox.WebGUI.Forms.Panel
		Friend WithEvents Panel6 As Gizmox.WebGUI.Forms.Panel
		Friend WithEvents GroupBox1 As Gizmox.WebGUI.Forms.GroupBox

	End Class

End Namespace
