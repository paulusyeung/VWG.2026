Namespace CompanionKit.Controls.ExpandableGroupBox

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
            Me.mobjExpColInfo = New Gizmox.WebGUI.Forms.Label()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjExpandableGroupBox3 = New Gizmox.WebGUI.Forms.ExpandableGroupBox()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjExpandableGroupBox2 = New Gizmox.WebGUI.Forms.ExpandableGroupBox()
            Me.mobjCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjExpandableGroupBox1 = New Gizmox.WebGUI.Forms.ExpandableGroupBox()
            Me.mobjButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjTLP.SuspendLayout()
            Me.mobjPanel.SuspendLayout()
            CType(Me.mobjExpandableGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjExpandableGroupBox3.SuspendLayout()
            CType(Me.mobjExpandableGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjExpandableGroupBox2.SuspendLayout()
            CType(Me.mobjExpandableGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjExpandableGroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjExpColInfo
            '
            Me.mobjExpColInfo.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjExpColInfo.Location = New System.Drawing.Point(0, 340)
            Me.mobjExpColInfo.Name = "mobjExpColInfo"
            Me.mobjExpColInfo.Size = New System.Drawing.Size(320, 60)
            Me.mobjExpColInfo.TabIndex = 2
            Me.mobjExpColInfo.Text = "Expanded: ExpandableGroupBox1"
            Me.mobjExpColInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjInfoLabel
            '
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 60)
            Me.mobjInfoLabel.TabIndex = 1
            Me.mobjInfoLabel.Text = "ExpandableGroupBoxes demonstrate Accordion behavior:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP.Controls.Add(Me.mobjExpColInfo, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjPanel, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 3
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 70.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 2
            '
            'mobjPanel
            '
            Me.mobjPanel.Controls.Add(Me.mobjExpandableGroupBox3)
            Me.mobjPanel.Controls.Add(Me.mobjExpandableGroupBox2)
            Me.mobjPanel.Controls.Add(Me.mobjExpandableGroupBox1)
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel.Location = New System.Drawing.Point(0, 60)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(320, 280)
            Me.mobjPanel.TabIndex = 0
            '
            'mobjExpandableGroupBox3
            '
            Me.mobjExpandableGroupBox3.Controls.Add(Me.mobjLabel)
            Me.mobjExpandableGroupBox3.CustomStyle = "X"
            Me.mobjExpandableGroupBox3.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjExpandableGroupBox3.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjExpandableGroupBox3.IsExpanded = False
            Me.mobjExpandableGroupBox3.Location = New System.Drawing.Point(0, 0)
            Me.mobjExpandableGroupBox3.Name = "mobjExpandableGroupBox3"
            Me.mobjExpandableGroupBox3.Size = New System.Drawing.Size(320, 90)
            Me.mobjExpandableGroupBox3.TabIndex = 2
            Me.mobjExpandableGroupBox3.Text = "expandableGroupBox3"
            '
            'mobjLabel
            '
            Me.mobjLabel.Location = New System.Drawing.Point(47, 36)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(123, 40)
            Me.mobjLabel.TabIndex = 0
            Me.mobjLabel.Text = "Label"
            '
            'mobjExpandableGroupBox2
            '
            Me.mobjExpandableGroupBox2.Controls.Add(Me.mobjCheckBox)
            Me.mobjExpandableGroupBox2.CustomStyle = "X"
            Me.mobjExpandableGroupBox2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjExpandableGroupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjExpandableGroupBox2.IsExpanded = False
            Me.mobjExpandableGroupBox2.Location = New System.Drawing.Point(0, 0)
            Me.mobjExpandableGroupBox2.Name = "mobjExpandableGroupBox2"
            Me.mobjExpandableGroupBox2.Size = New System.Drawing.Size(320, 90)
            Me.mobjExpandableGroupBox2.TabIndex = 1
            Me.mobjExpandableGroupBox2.Text = "expandableGroupBox2"
            '
            'mobjCheckBox
            '
            Me.mobjCheckBox.Location = New System.Drawing.Point(50, 34)
            Me.mobjCheckBox.Name = "mobjCheckBox"
            Me.mobjCheckBox.Size = New System.Drawing.Size(120, 40)
            Me.mobjCheckBox.TabIndex = 0
            Me.mobjCheckBox.Text = "CheckBox"
            '
            'mobjExpandableGroupBox1
            '
            Me.mobjExpandableGroupBox1.Controls.Add(Me.mobjButton)
            Me.mobjExpandableGroupBox1.CustomStyle = "X"
            Me.mobjExpandableGroupBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjExpandableGroupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjExpandableGroupBox1.Location = New System.Drawing.Point(0, 0)
            Me.mobjExpandableGroupBox1.Name = "mobjExpandableGroupBox1"
            Me.mobjExpandableGroupBox1.Size = New System.Drawing.Size(320, 90)
            Me.mobjExpandableGroupBox1.TabIndex = 0
            Me.mobjExpandableGroupBox1.Text = "expandableGroupBox1"
            '
            'mobjButton
            '
            Me.mobjButton.Location = New System.Drawing.Point(50, 34)
            Me.mobjButton.Name = "mobjButton"
            Me.mobjButton.Size = New System.Drawing.Size(120, 30)
            Me.mobjButton.TabIndex = 0
            Me.mobjButton.Text = "Button"
            '
            'ExpandCollapsePage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "ExpandCollapsePage"
            Me.mobjTLP.ResumeLayout(False)
            Me.mobjPanel.ResumeLayout(False)
            CType(Me.mobjExpandableGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjExpandableGroupBox3.ResumeLayout(False)
            CType(Me.mobjExpandableGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjExpandableGroupBox2.ResumeLayout(False)
            CType(Me.mobjExpandableGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjExpandableGroupBox1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents mobjExpColInfo As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private WithEvents mobjPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents mobjExpandableGroupBox3 As Gizmox.WebGUI.Forms.ExpandableGroupBox
        Private WithEvents mobjExpandableGroupBox2 As Gizmox.WebGUI.Forms.ExpandableGroupBox
        Private WithEvents mobjExpandableGroupBox1 As Gizmox.WebGUI.Forms.ExpandableGroupBox
        Private WithEvents mobjLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjButton As Gizmox.WebGUI.Forms.Button
	End Class

End Namespace