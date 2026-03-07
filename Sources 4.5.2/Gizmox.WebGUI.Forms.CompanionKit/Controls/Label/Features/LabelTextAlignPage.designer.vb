Namespace CompanionKit.Controls.LabelFolder.Features

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class LabelTextAlignPage
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
            Me.mobjLabel1 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLabel2 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLabel3 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjCB1 = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjCB2 = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjCB3 = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjLabel1
            '
            Me.mobjLabel1.Anchor = CType((((Gizmox.WebGUI.Forms.AnchorStyles.Top Or Gizmox.WebGUI.Forms.AnchorStyles.Bottom) _
                Or Gizmox.WebGUI.Forms.AnchorStyles.Left) _
                Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjLabel1.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black)
            Me.mobjLabel1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjLabel1.Location = New System.Drawing.Point(10, 10)
            Me.mobjLabel1.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.mobjLabel1.Name = "mobjLabel1"
            Me.mobjLabel1.Size = New System.Drawing.Size(140, 96)
            Me.mobjLabel1.TabIndex = 0
            Me.mobjLabel1.Text = "Label text"
            Me.mobjLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjLabel2
            '
            Me.mobjLabel2.Anchor = CType((((Gizmox.WebGUI.Forms.AnchorStyles.Top Or Gizmox.WebGUI.Forms.AnchorStyles.Bottom) _
                Or Gizmox.WebGUI.Forms.AnchorStyles.Left) _
                Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjLabel2.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black)
            Me.mobjLabel2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjLabel2.Location = New System.Drawing.Point(10, 126)
            Me.mobjLabel2.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.mobjLabel2.Name = "mobjLabel2"
            Me.mobjLabel2.Size = New System.Drawing.Size(140, 96)
            Me.mobjLabel2.TabIndex = 1
            Me.mobjLabel2.Text = "Label text"
            Me.mobjLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjLabel3
            '
            Me.mobjLabel3.Anchor = CType((((Gizmox.WebGUI.Forms.AnchorStyles.Top Or Gizmox.WebGUI.Forms.AnchorStyles.Bottom) _
                Or Gizmox.WebGUI.Forms.AnchorStyles.Left) _
                Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjLabel3.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black)
            Me.mobjLabel3.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjLabel3.Location = New System.Drawing.Point(10, 242)
            Me.mobjLabel3.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.mobjLabel3.Name = "mobjLabel3"
            Me.mobjLabel3.Size = New System.Drawing.Size(140, 98)
            Me.mobjLabel3.TabIndex = 2
            Me.mobjLabel3.Text = "Label text"
            Me.mobjLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjCB1
            '
            Me.mobjCB1.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjCB1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjCB1.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjCB1.FormattingEnabled = True
            Me.mobjCB1.Location = New System.Drawing.Point(160, 47)
            Me.mobjCB1.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjCB1.Name = "mobjCB1"
            Me.mobjCB1.Size = New System.Drawing.Size(160, 25)
            Me.mobjCB1.TabIndex = 3
            '
            'mobjCB2
            '
            Me.mobjCB2.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjCB2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjCB2.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjCB2.FormattingEnabled = True
            Me.mobjCB2.Location = New System.Drawing.Point(160, 163)
            Me.mobjCB2.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjCB2.Name = "mobjCB2"
            Me.mobjCB2.Size = New System.Drawing.Size(160, 25)
            Me.mobjCB2.TabIndex = 4
            '
            'mobjCB3
            '
            Me.mobjCB3.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjCB3.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjCB3.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjCB3.FormattingEnabled = True
            Me.mobjCB3.Location = New System.Drawing.Point(160, 280)
            Me.mobjCB3.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjCB3.Name = "mobjCB3"
            Me.mobjCB3.Size = New System.Drawing.Size(160, 25)
            Me.mobjCB3.TabIndex = 5
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjLabel1, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjCB3, 1, 2)
            Me.mobjTLP.Controls.Add(Me.mobjLabel2, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjCB2, 1, 1)
            Me.mobjTLP.Controls.Add(Me.mobjLabel3, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjCB1, 1, 0)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 3
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 350)
            Me.mobjTLP.TabIndex = 6
            '
            'LabelTextAlignPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 350)
            Me.Text = "LabelTextAlignPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjLabel1 As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjLabel2 As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjLabel3 As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjCB1 As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents mobjCB2 As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents mobjCB3 As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

    End Class

End Namespace