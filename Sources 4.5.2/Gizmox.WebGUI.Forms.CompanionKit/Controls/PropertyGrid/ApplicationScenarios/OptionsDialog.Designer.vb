<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsDialog
    Inherits Gizmox.WebGUI.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Visual WebGui Designer
    Private Shadows components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Visual WebGui Designer
    'It can be modified using the Visual WebGui Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.optionsPropertyGrid = New Gizmox.WebGUI.Forms.PropertyGrid
        Me.SuspendLayout()
        '
        'optionsPropertyGrid
        '
        Me.optionsPropertyGrid.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
        Me.optionsPropertyGrid.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
        Me.optionsPropertyGrid.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
        Me.optionsPropertyGrid.CategoryForeColor = System.Drawing.Color.Empty
        Me.optionsPropertyGrid.CommandsVisibleIfAvailable = False
        Me.optionsPropertyGrid.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
        Me.optionsPropertyGrid.HelpBackColor = System.Drawing.Color.Transparent
        Me.optionsPropertyGrid.HelpForeColor = System.Drawing.Color.Black
        Me.optionsPropertyGrid.LineColor = System.Drawing.Color.Empty
        Me.optionsPropertyGrid.Location = New System.Drawing.Point(0, 0)
        Me.optionsPropertyGrid.Name = "optionsPropertyGrid"
        Me.optionsPropertyGrid.PropertySort = Gizmox.WebGUI.Forms.PropertySort.CategorizedAlphabetical
        Me.optionsPropertyGrid.Size = New System.Drawing.Size(419, 466)
        Me.optionsPropertyGrid.TabIndex = 0
        Me.optionsPropertyGrid.ViewBackColor = System.Drawing.Color.White
        Me.optionsPropertyGrid.ViewForeColor = System.Drawing.Color.Black
        '
        'OptionsDialog
        '
        Me.Controls.Add(Me.optionsPropertyGrid)
        Me.Size = New System.Drawing.Size(419, 466)
        Me.Text = "OptionsDialog"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents optionsPropertyGrid As Gizmox.WebGUI.Forms.PropertyGrid

End Class