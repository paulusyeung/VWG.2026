Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Features

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class StatelessPropertyFalseForm
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
            Me.lblDayofWeek = New Gizmox.WebGUI.Forms.Label
            Me.btnSet = New Gizmox.WebGUI.Forms.Button
            Me.cmbDaysOfWeek = New Gizmox.WebGUI.Forms.ComboBox
            Me.SuspendLayout()
            '
            'lblDayofWeek
            '
            Me.lblDayofWeek.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Black)
            Me.lblDayofWeek.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.lblDayofWeek.Location = New System.Drawing.Point(40, 74)
            Me.lblDayofWeek.Name = "lblDayofWeek"
            Me.lblDayofWeek.Size = New System.Drawing.Size(121, 23)
            Me.lblDayofWeek.TabIndex = 2
            Me.lblDayofWeek.Text = "Day of Week"
            Me.lblDayofWeek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnSet
            '
            Me.btnSet.Location = New System.Drawing.Point(40, 40)
            Me.btnSet.Name = "btnSet"
            Me.btnSet.Size = New System.Drawing.Size(121, 23)
            Me.btnSet.TabIndex = 1
            Me.btnSet.Text = "Set Value to Label"
            '
            'cmbDaysOfWeek
            '
            Me.cmbDaysOfWeek.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.cmbDaysOfWeek.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.cmbDaysOfWeek.FormattingEnabled = True
            Me.cmbDaysOfWeek.Location = New System.Drawing.Point(40, 9)
            Me.cmbDaysOfWeek.MaxDropDownItems = 8
            Me.cmbDaysOfWeek.Name = "cmbDaysOfWeek"
            Me.cmbDaysOfWeek.Size = New System.Drawing.Size(121, 21)
            Me.cmbDaysOfWeek.TabIndex = 0
            '
            'StatelessPropertyFalseForm
            '
            Me.Controls.Add(Me.cmbDaysOfWeek)
            Me.Controls.Add(Me.btnSet)
            Me.Controls.Add(Me.lblDayofWeek)
            Me.Size = New System.Drawing.Size(200, 150)
            Me.Text = "StatelessPropertyFalseForm"
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents lblDayofWeek As Gizmox.WebGUI.Forms.Label
        Private WithEvents btnSet As Gizmox.WebGUI.Forms.Button
        Private WithEvents cmbDaysOfWeek As Gizmox.WebGUI.Forms.ComboBox

    End Class

End Namespace
