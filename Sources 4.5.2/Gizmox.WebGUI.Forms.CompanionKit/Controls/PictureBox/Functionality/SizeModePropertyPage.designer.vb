Namespace CompanionKit.Controls.PictureBox.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class SizeModePropertyPage
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SizeModePropertyPage))
            Me.mobjPictureBox = New Gizmox.WebGUI.Forms.PictureBox()
            Me.mobjSizeModeLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjSizeModeComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            CType(Me.mobjPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjPictureBox
            '
            Me.mobjPictureBox.BackgroundImage = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjPictureBox.BackgroundImage"))
            Me.mobjTLP.SetColumnSpan(Me.mobjPictureBox, 2)
            Me.mobjPictureBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPictureBox.Image = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjPictureBox.Image"))
            Me.mobjPictureBox.Location = New System.Drawing.Point(10, 90)
            Me.mobjPictureBox.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.mobjPictureBox.Name = "mobjPictureBox"
            Me.mobjPictureBox.Size = New System.Drawing.Size(300, 300)
            Me.mobjPictureBox.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.CenterImage
            Me.mobjPictureBox.TabIndex = 0
            Me.mobjPictureBox.TabStop = False
            '
            'mobjSizeModeLabel
            '
            Me.mobjSizeModeLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSizeModeLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjSizeModeLabel.Name = "mobjSizeModeLabel"
            Me.mobjSizeModeLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjSizeModeLabel.Size = New System.Drawing.Size(160, 80)
            Me.mobjSizeModeLabel.TabIndex = 1
            Me.mobjSizeModeLabel.Text = "Size mode for the PictureBox"
            Me.mobjSizeModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjSizeModeComboBox
            '
            Me.mobjSizeModeComboBox.AllowDrag = False
            Me.mobjSizeModeComboBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjSizeModeComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjSizeModeComboBox.Location = New System.Drawing.Point(160, 29)
            Me.mobjSizeModeComboBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjSizeModeComboBox.Name = "mobjSizeModeComboBox"
            Me.mobjSizeModeComboBox.Size = New System.Drawing.Size(160, 25)
            Me.mobjSizeModeComboBox.TabIndex = 2
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjSizeModeLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjPictureBox, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjSizeModeComboBox, 1, 0)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 2
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 3
            '
            'SizeModePropertyPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "SizeModePropertyPage"
            CType(Me.mobjPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents mobjPictureBox As Gizmox.WebGUI.Forms.PictureBox
        Friend WithEvents mobjSizeModeLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjSizeModeComboBox As Gizmox.WebGUI.Forms.ComboBox
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace