Namespace CompanionKit.Controls.ListBox.Appearance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class TextWithImagePage
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
            Me.BindingSource1 = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjImageMemLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjImageTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjValueTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjDisplayTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjValueMemLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDisplayMemLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP1 = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP2 = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjTLP1.SuspendLayout()
            Me.mobjTLP2.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjListBox
            '
            Me.mobjListBox.DataSource = Me.BindingSource1
            Me.mobjListBox.DisplayMember = "FullName"
            Me.mobjListBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjListBox.ImageMember = "Photo"
            Me.mobjListBox.Location = New System.Drawing.Point(0, 60)
            Me.mobjListBox.Name = "mobjListBox"
            Me.mobjListBox.Size = New System.Drawing.Size(320, 199)
            Me.mobjListBox.TabIndex = 0
            Me.mobjListBox.ValueMember = "ID"
            '
            'BindingSource1
            '
            Me.BindingSource1.DataSource = GetType(CompanionKit.Controls.Utils.Customer)
            '
            'mobjLabel
            '
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(320, 60)
            Me.mobjLabel.TabIndex = 1
            Me.mobjLabel.Text = "ListBox with Image:"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjImageMemLabel
            '
            Me.mobjImageMemLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjImageMemLabel.Location = New System.Drawing.Point(0, 92)
            Me.mobjImageMemLabel.Name = "mobjImageMemLabel"
            Me.mobjImageMemLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjImageMemLabel.Size = New System.Drawing.Size(160, 48)
            Me.mobjImageMemLabel.TabIndex = 7
            Me.mobjImageMemLabel.Text = "ImageMember"
            Me.mobjImageMemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjImageTextBox
            '
            Me.mobjImageTextBox.AllowDrag = False
            Me.mobjImageTextBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjImageTextBox.Location = New System.Drawing.Point(163, 103)
            Me.mobjImageTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjImageTextBox.Name = "mobjImageTextBox"
            Me.mobjImageTextBox.ReadOnly = True
            Me.mobjImageTextBox.Size = New System.Drawing.Size(154, 25)
            Me.mobjImageTextBox.TabIndex = 6
            '
            'mobjValueTextBox
            '
            Me.mobjValueTextBox.AllowDrag = False
            Me.mobjValueTextBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjValueTextBox.Location = New System.Drawing.Point(163, 56)
            Me.mobjValueTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjValueTextBox.Name = "mobjValueTextBox"
            Me.mobjValueTextBox.ReadOnly = True
            Me.mobjValueTextBox.Size = New System.Drawing.Size(154, 25)
            Me.mobjValueTextBox.TabIndex = 5
            '
            'mobjDisplayTextBox
            '
            Me.mobjDisplayTextBox.AllowDrag = False
            Me.mobjDisplayTextBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjDisplayTextBox.Location = New System.Drawing.Point(163, 10)
            Me.mobjDisplayTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjDisplayTextBox.Name = "mobjDisplayTextBox"
            Me.mobjDisplayTextBox.ReadOnly = True
            Me.mobjDisplayTextBox.Size = New System.Drawing.Size(154, 25)
            Me.mobjDisplayTextBox.TabIndex = 4
            '
            'mobjValueMemLabel
            '
            Me.mobjValueMemLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjValueMemLabel.Location = New System.Drawing.Point(0, 46)
            Me.mobjValueMemLabel.Name = "mobjValueMemLabel"
            Me.mobjValueMemLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjValueMemLabel.Size = New System.Drawing.Size(160, 46)
            Me.mobjValueMemLabel.TabIndex = 3
            Me.mobjValueMemLabel.Text = "ValueMember"
            Me.mobjValueMemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjDisplayMemLabel
            '
            Me.mobjDisplayMemLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDisplayMemLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjDisplayMemLabel.Name = "mobjDisplayMemLabel"
            Me.mobjDisplayMemLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjDisplayMemLabel.Size = New System.Drawing.Size(160, 46)
            Me.mobjDisplayMemLabel.TabIndex = 2
            Me.mobjDisplayMemLabel.Text = "DisplayMember"
            Me.mobjDisplayMemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjTLP1
            '
            Me.mobjTLP1.ColumnCount = 1
            Me.mobjTLP1.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP1.Controls.Add(Me.mobjLabel, 0, 0)
            Me.mobjTLP1.Controls.Add(Me.mobjListBox, 0, 1)
            Me.mobjTLP1.Controls.Add(Me.mobjTLP2, 0, 2)
            Me.mobjTLP1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP1.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP1.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP1.Name = "mobjTLP1"
            Me.mobjTLP1.RowCount = 3
            Me.mobjTLP1.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP1.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP1.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 35.0!))
            Me.mobjTLP1.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP1.TabIndex = 8
            '
            'mobjTLP2
            '
            Me.mobjTLP2.ColumnCount = 2
            Me.mobjTLP2.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP2.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP2.Controls.Add(Me.mobjDisplayMemLabel, 0, 0)
            Me.mobjTLP2.Controls.Add(Me.mobjImageTextBox, 1, 2)
            Me.mobjTLP2.Controls.Add(Me.mobjValueTextBox, 1, 1)
            Me.mobjTLP2.Controls.Add(Me.mobjValueMemLabel, 0, 1)
            Me.mobjTLP2.Controls.Add(Me.mobjImageMemLabel, 0, 2)
            Me.mobjTLP2.Controls.Add(Me.mobjDisplayTextBox, 1, 0)
            Me.mobjTLP2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP2.Location = New System.Drawing.Point(0, 260)
            Me.mobjTLP2.Name = "mobjTLP2"
            Me.mobjTLP2.RowCount = 3
            Me.mobjTLP2.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333!))
            Me.mobjTLP2.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333!))
            Me.mobjTLP2.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333!))
            Me.mobjTLP2.Size = New System.Drawing.Size(320, 140)
            Me.mobjTLP2.TabIndex = 0
            '
            'TextWithImagePage
            '
            Me.Controls.Add(Me.mobjTLP1)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "TextWithImagePage"
            CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjTLP1.ResumeLayout(False)
            Me.mobjTLP2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mobjListBox As Gizmox.WebGUI.Forms.ListBox
        Friend WithEvents BindingSource1 As Gizmox.WebGUI.Forms.BindingSource
        Friend WithEvents mobjLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjImageMemLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjImageTextBox As Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents mobjValueTextBox As Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents mobjDisplayTextBox As Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents mobjValueMemLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjDisplayMemLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjTLP1 As Gizmox.WebGUI.Forms.TableLayoutPanel
        Friend WithEvents mobjTLP2 As Gizmox.WebGUI.Forms.TableLayoutPanel
    End Class

End Namespace
