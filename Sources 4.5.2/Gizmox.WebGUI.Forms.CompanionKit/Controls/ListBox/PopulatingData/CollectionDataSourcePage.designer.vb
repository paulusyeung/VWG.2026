Namespace CompanionKit.Controls.ListBox.PopulatingData

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class CollectionDataSourcePage
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
            Me.components = New System.ComponentModel.Container()
            Me.mobjListBox = New Gizmox.WebGUI.Forms.ListBox()
            Me.bindingSource1 = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjValueText = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjDisplayText = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjValueLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDisplayLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            CType(Me.bindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjListBox
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjListBox, 2)
            Me.mobjListBox.DataSource = Me.bindingSource1
            Me.mobjListBox.DisplayMember = "FullName"
            Me.mobjListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListBox.Location = New System.Drawing.Point(0, 52)
            Me.mobjListBox.Name = "mobjListBox"
            Me.mobjListBox.Size = New System.Drawing.Size(320, 186)
            Me.mobjListBox.TabIndex = 0
            Me.mobjListBox.ValueMember = "ID"
            '
            'bindingSource1
            '
            Me.bindingSource1.DataSource = GetType(CompanionKit.Controls.Utils.Customer)
            '
            'mobjInfoLabel
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjInfoLabel, 2)
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 52)
            Me.mobjInfoLabel.TabIndex = 1
            Me.mobjInfoLabel.Text = "ListBox with a collection DataSource:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjValueText
            '
            Me.mobjValueText.AllowDrag = False
            Me.mobjValueText.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjValueText.Location = New System.Drawing.Point(163, 310)
            Me.mobjValueText.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjValueText.Name = "mobjValueText"
            Me.mobjValueText.ReadOnly = True
            Me.mobjValueText.Size = New System.Drawing.Size(154, 25)
            Me.mobjValueText.TabIndex = 5
            '
            'mobjDisplayText
            '
            Me.mobjDisplayText.AllowDrag = False
            Me.mobjDisplayText.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjDisplayText.Location = New System.Drawing.Point(163, 257)
            Me.mobjDisplayText.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjDisplayText.Name = "mobjDisplayText"
            Me.mobjDisplayText.ReadOnly = True
            Me.mobjDisplayText.Size = New System.Drawing.Size(154, 25)
            Me.mobjDisplayText.TabIndex = 4
            '
            'mobjValueLabel
            '
            Me.mobjValueLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjValueLabel.Location = New System.Drawing.Point(0, 296)
            Me.mobjValueLabel.Name = "mobjValueLabel"
            Me.mobjValueLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjValueLabel.Size = New System.Drawing.Size(160, 54)
            Me.mobjValueLabel.TabIndex = 3
            Me.mobjValueLabel.Text = "Value Member"
            Me.mobjValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjDisplayLabel
            '
            Me.mobjDisplayLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDisplayLabel.Location = New System.Drawing.Point(0, 244)
            Me.mobjDisplayLabel.Name = "mobjDisplayLabel"
            Me.mobjDisplayLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjDisplayLabel.Size = New System.Drawing.Size(160, 52)
            Me.mobjDisplayLabel.TabIndex = 2
            Me.mobjDisplayLabel.Text = "Display Member"
            Me.mobjDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjValueText, 1, 3)
            Me.mobjTLP.Controls.Add(Me.mobjDisplayText, 1, 2)
            Me.mobjTLP.Controls.Add(Me.mobjValueLabel, 0, 3)
            Me.mobjTLP.Controls.Add(Me.mobjDisplayLabel, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjListBox, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 4
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 55.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 350)
            Me.mobjTLP.TabIndex = 6
            '
            'CollectionDataSourcePage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 350)
            Me.Text = "CollectionDataSourcePage"
            CType(Me.bindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjListBox As Gizmox.WebGUI.Forms.ListBox
        Friend WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents bindingSource1 As Gizmox.WebGUI.Forms.BindingSource
        Friend WithEvents mobjValueText As Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents mobjDisplayText As Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents mobjValueLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjDisplayLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
