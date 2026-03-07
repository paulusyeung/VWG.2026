Namespace CompanionKit.Controls.LabelFolder.Features

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class LabelImagePage
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LabelImagePage))
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.cmbImageAlignment = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjLabel
            '
            Me.mobjLabel.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black)
            Me.mobjLabel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjTLP.SetColumnSpan(Me.mobjLabel, 2)
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel.Image = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjLabel.Image"))
            Me.mobjLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.mobjLabel.Location = New System.Drawing.Point(10, 10)
            Me.mobjLabel.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(300, 155)
            Me.mobjLabel.TabIndex = 0
            Me.mobjLabel.Text = "Tabel Text"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cmbImageAlignment
            '
            Me.cmbImageAlignment.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.cmbImageAlignment.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.cmbImageAlignment.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.cmbImageAlignment.FormattingEnabled = True
            Me.cmbImageAlignment.Location = New System.Drawing.Point(160, 252)
            Me.cmbImageAlignment.MaximumSize = New System.Drawing.Size(200, 0)
            Me.cmbImageAlignment.Name = "cmbImageAlignment"
            Me.cmbImageAlignment.Size = New System.Drawing.Size(160, 25)
            Me.cmbImageAlignment.TabIndex = 1
            '
            'mobjInfoLabel
            '
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 175)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjInfoLabel.Size = New System.Drawing.Size(160, 175)
            Me.mobjInfoLabel.TabIndex = 2
            Me.mobjInfoLabel.Text = "Image alignment"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.cmbImageAlignment, 1, 1)
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 2
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 350)
            Me.mobjTLP.TabIndex = 3
            '
            'LabelImagePage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 350)
            Me.Text = "LabelImagePage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents mobjLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents cmbImageAlignment As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

    End Class

End Namespace