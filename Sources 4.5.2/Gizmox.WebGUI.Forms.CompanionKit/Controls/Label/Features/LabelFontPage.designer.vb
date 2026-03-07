Namespace CompanionKit.Controls.LabelFolder.Features

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class LabelFontPage
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
            Me.mobjButton1 = New Gizmox.WebGUI.Forms.Button()
            Me.mobjButton2 = New Gizmox.WebGUI.Forms.Button()
            Me.mobjButton3 = New Gizmox.WebGUI.Forms.Button()
            Me.fontDialog1 = New Gizmox.WebGUI.Forms.FontDialog()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjLabel1
            '
            Me.mobjLabel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.mobjLabel1.Location = New System.Drawing.Point(210, 10)
            Me.mobjLabel1.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.mobjLabel1.Name = "mobjLabel1"
            Me.mobjLabel1.Size = New System.Drawing.Size(140, 96)
            Me.mobjLabel1.TabIndex = 0
            Me.mobjLabel1.Text = "Label Text"
            Me.mobjLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'mobjLabel2
            '
            Me.mobjLabel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel2.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.mobjLabel2.Location = New System.Drawing.Point(170, 126)
            Me.mobjLabel2.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.mobjLabel2.Name = "mobjLabel2"
            Me.mobjLabel2.Size = New System.Drawing.Size(140, 96)
            Me.mobjLabel2.TabIndex = 1
            Me.mobjLabel2.Text = "Label Text"
            Me.mobjLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'mobjLabel3
            '
            Me.mobjLabel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel3.Font = New System.Drawing.Font("Monotype Corsiva", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
            Me.mobjLabel3.Location = New System.Drawing.Point(170, 242)
            Me.mobjLabel3.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.mobjLabel3.Name = "mobjLabel3"
            Me.mobjLabel3.Size = New System.Drawing.Size(140, 98)
            Me.mobjLabel3.TabIndex = 2
            Me.mobjLabel3.Text = "Label Text"
            Me.mobjLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'mobjButton1
            '
            Me.mobjButton1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjButton1.Location = New System.Drawing.Point(15, 15)
            Me.mobjButton1.Margin = New Gizmox.WebGUI.Forms.Padding(15)
            Me.mobjButton1.Name = "mobjButton1"
            Me.mobjButton1.Size = New System.Drawing.Size(130, 86)
            Me.mobjButton1.TabIndex = 3
            Me.mobjButton1.Text = "Set font"
            Me.mobjButton1.UseVisualStyleBackColor = True
            '
            'mobjButton2
            '
            Me.mobjButton2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjButton2.Location = New System.Drawing.Point(15, 131)
            Me.mobjButton2.Margin = New Gizmox.WebGUI.Forms.Padding(15)
            Me.mobjButton2.Name = "mobjButton2"
            Me.mobjButton2.Size = New System.Drawing.Size(130, 86)
            Me.mobjButton2.TabIndex = 4
            Me.mobjButton2.Text = "Set font"
            Me.mobjButton2.UseVisualStyleBackColor = True
            '
            'mobjButton3
            '
            Me.mobjButton3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjButton3.Location = New System.Drawing.Point(15, 247)
            Me.mobjButton3.Margin = New Gizmox.WebGUI.Forms.Padding(15)
            Me.mobjButton3.Name = "mobjButton3"
            Me.mobjButton3.Size = New System.Drawing.Size(130, 88)
            Me.mobjButton3.TabIndex = 5
            Me.mobjButton3.Text = "Set font"
            Me.mobjButton3.UseVisualStyleBackColor = True
            '
            'fontDialog1
            '
            Me.fontDialog1.MaxSize = 72
            Me.fontDialog1.MinSize = 8
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjButton1, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjLabel3, 1, 2)
            Me.mobjTLP.Controls.Add(Me.mobjButton3, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjLabel2, 1, 1)
            Me.mobjTLP.Controls.Add(Me.mobjButton2, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjLabel1, 1, 0)
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
            'LabelFontPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 350)
            Me.Text = "LabelFontPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjLabel1 As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjLabel2 As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjLabel3 As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjButton1 As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjButton2 As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjButton3 As Gizmox.WebGUI.Forms.Button
        Private WithEvents fontDialog1 As Gizmox.WebGUI.Forms.FontDialog
        Private WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

    End Class

End Namespace