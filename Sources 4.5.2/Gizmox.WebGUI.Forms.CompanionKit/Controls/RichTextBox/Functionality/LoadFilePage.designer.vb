Namespace CompanionKit.Controls.RichTextBox.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class LoadFilePage
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
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjRichTextBox = New Gizmox.WebGUI.Forms.RichTextBox()
            Me.mobjListView = New Gizmox.WebGUI.Forms.ListView()
            Me.listViewItem1 = New Gizmox.WebGUI.Forms.ListViewItem("Sample.rtf")
            Me.listViewItem2 = New Gizmox.WebGUI.Forms.ListViewItem("Scenario.rtf")
            Me.listViewItem3 = New Gizmox.WebGUI.Forms.ListViewItem("List.rtf")
            Me.mobjLoadButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjInfoLabel
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjInfoLabel, 2)
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 70)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "Select file name and click button to load it to RichTextBox:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjRichTextBox
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjRichTextBox, 2)
            Me.mobjRichTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjRichTextBox.Location = New System.Drawing.Point(10, 185)
            Me.mobjRichTextBox.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.mobjRichTextBox.Name = "mobjRichTextBox"
            Me.mobjRichTextBox.Size = New System.Drawing.Size(300, 155)
            Me.mobjRichTextBox.TabIndex = 2
            '
            'mobjListView
            '
            Me.mobjListView.DataMember = Nothing
            Me.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListView.Items.AddRange(New Gizmox.WebGUI.Forms.ListViewItem() {Me.listViewItem1, Me.listViewItem2, Me.listViewItem3})
            Me.mobjListView.Location = New System.Drawing.Point(0, 70)
            Me.mobjListView.MultiSelect = False
            Me.mobjListView.Name = "mobjListView"
            Me.mobjListView.Size = New System.Drawing.Size(160, 105)
            Me.mobjListView.TabIndex = 3
            Me.mobjListView.View = Gizmox.WebGUI.Forms.View.List
            '
            'listViewItem1
            '
            Me.listViewItem1.BackColor = System.Drawing.SystemColors.Window
            Me.listViewItem1.Font = New System.Drawing.Font("Tahoma", 8.25!)
            Me.listViewItem1.ForeColor = System.Drawing.SystemColors.WindowText
            Me.listViewItem1.Text = "Sample.rtf"
            '
            'listViewItem2
            '
            Me.listViewItem2.BackColor = System.Drawing.SystemColors.Window
            Me.listViewItem2.Font = New System.Drawing.Font("Tahoma", 8.25!)
            Me.listViewItem2.ForeColor = System.Drawing.SystemColors.WindowText
            Me.listViewItem2.Text = "Scenario.rtf"
            '
            'listViewItem3
            '
            Me.listViewItem3.BackColor = System.Drawing.SystemColors.Window
            Me.listViewItem3.Font = New System.Drawing.Font("Tahoma", 8.25!)
            Me.listViewItem3.ForeColor = System.Drawing.SystemColors.WindowText
            Me.listViewItem3.Text = "List.rtf"
            '
            'mobjLoadButton
            '
            Me.mobjLoadButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLoadButton.Location = New System.Drawing.Point(170, 80)
            Me.mobjLoadButton.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.mobjLoadButton.MaximumSize = New System.Drawing.Size(0, 80)
            Me.mobjLoadButton.Name = "mobjLoadButton"
            Me.mobjLoadButton.Size = New System.Drawing.Size(140, 80)
            Me.mobjLoadButton.TabIndex = 4
            Me.mobjLoadButton.Text = "Load"
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjLoadButton, 1, 1)
            Me.mobjTLP.Controls.Add(Me.mobjListView, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjRichTextBox, 0, 2)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 3
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 30.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 350)
            Me.mobjTLP.TabIndex = 5
            '
            'LoadFilePage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 350)
            Me.Text = "LoadFilePage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjRichTextBox As Gizmox.WebGUI.Forms.RichTextBox
        Private WithEvents mobjListView As Gizmox.WebGUI.Forms.ListView
        Private WithEvents listViewItem1 As Gizmox.WebGUI.Forms.ListViewItem
        Private WithEvents listViewItem2 As Gizmox.WebGUI.Forms.ListViewItem
        Private WithEvents listViewItem3 As Gizmox.WebGUI.Forms.ListViewItem
        Private WithEvents mobjLoadButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace