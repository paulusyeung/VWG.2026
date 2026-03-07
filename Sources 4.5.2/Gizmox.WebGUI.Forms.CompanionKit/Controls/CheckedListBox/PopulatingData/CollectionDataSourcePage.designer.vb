Namespace CompanionKit.Controls.CheckedListBox.PopulatingData

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
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjCheckedListBox = New Gizmox.WebGUI.Forms.CheckedListBox()
            Me.bindingSource1 = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjDisplayTB = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjValueTB = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjDisplayLbl = New Gizmox.WebGUI.Forms.Label()
            Me.mobjValueLbl = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            CType(Me.bindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjInfoLabel
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjInfoLabel, 2)
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 45)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "CheckedListBox with Collection DataSource:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjCheckedListBox
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjCheckedListBox, 2)
            Me.mobjCheckedListBox.DataSource = Me.bindingSource1
            Me.mobjCheckedListBox.DisplayMember = "FullName"
            Me.mobjCheckedListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCheckedListBox.Location = New System.Drawing.Point(0, 45)
            Me.mobjCheckedListBox.Name = "mobjCheckedListBox"
            Me.mobjCheckedListBox.Size = New System.Drawing.Size(320, 180)
            Me.mobjCheckedListBox.TabIndex = 1
            Me.mobjCheckedListBox.ValueMember = "ID"
            '
            'mobjDisplayTB
            '
            Me.mobjDisplayTB.AllowDrag = False
            Me.mobjDisplayTB.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjDisplayTB.Location = New System.Drawing.Point(163, 273)
            Me.mobjDisplayTB.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjDisplayTB.Name = "mobjDisplayTB"
            Me.mobjDisplayTB.ReadOnly = True
            Me.mobjDisplayTB.Size = New System.Drawing.Size(154, 24)
            Me.mobjDisplayTB.TabIndex = 5
            '
            'mobjValueTB
            '
            Me.mobjValueTB.AllowDrag = False
            Me.mobjValueTB.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjValueTB.Location = New System.Drawing.Point(163, 243)
            Me.mobjValueTB.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjValueTB.Name = "mobjValueTB"
            Me.mobjValueTB.ReadOnly = True
            Me.mobjValueTB.Size = New System.Drawing.Size(154, 24)
            Me.mobjValueTB.TabIndex = 4
            '
            'mobjDisplayLbl
            '
            Me.mobjDisplayLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDisplayLbl.Location = New System.Drawing.Point(0, 270)
            Me.mobjDisplayLbl.Name = "mobjDisplayLbl"
            Me.mobjDisplayLbl.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjDisplayLbl.Size = New System.Drawing.Size(160, 30)
            Me.mobjDisplayLbl.TabIndex = 3
            Me.mobjDisplayLbl.Text = "DisplayMember"
            Me.mobjDisplayLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjValueLbl
            '
            Me.mobjValueLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjValueLbl.Location = New System.Drawing.Point(0, 240)
            Me.mobjValueLbl.Name = "mobjValueLbl"
            Me.mobjValueLbl.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjValueLbl.Size = New System.Drawing.Size(160, 30)
            Me.mobjValueLbl.TabIndex = 2
            Me.mobjValueLbl.Text = "ValueMember"
            Me.mobjValueLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjDisplayTB, 1, 3)
            Me.mobjTLP.Controls.Add(Me.mobjValueTB, 1, 2)
            Me.mobjTLP.Controls.Add(Me.mobjDisplayLbl, 0, 3)
            Me.mobjTLP.Controls.Add(Me.mobjCheckedListBox, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjValueLbl, 0, 2)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 4
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 65.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 300)
            Me.mobjTLP.TabIndex = 6
            '
            'CollectionDataSourcePage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 300)
            Me.Text = "CollectionDataSourcePage"
            CType(Me.bindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjCheckedListBox As Gizmox.WebGUI.Forms.CheckedListBox
        Friend WithEvents bindingSource1 As Gizmox.WebGUI.Forms.BindingSource
        Friend WithEvents mobjDisplayTB As Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents mobjValueTB As Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents mobjDisplayLbl As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjValueLbl As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
