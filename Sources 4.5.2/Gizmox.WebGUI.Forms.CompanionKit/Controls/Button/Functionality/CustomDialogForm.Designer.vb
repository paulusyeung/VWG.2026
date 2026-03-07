Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomDialogForm
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
        Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.Panel()
        Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
        Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
        Me.mobjNoButton = New Gizmox.WebGUI.Forms.Button()
        Me.mobjYesButton = New Gizmox.WebGUI.Forms.Button()
        Me.mobjLayoutPanel.SuspendLayout()
        Me.mobjPanel.SuspendLayout()
        Me.SuspendLayout()
        ' 
        ' mobjLayoutPanel
        ' 
        Me.mobjLayoutPanel.AccessibleDescription = ""
        Me.mobjLayoutPanel.AccessibleName = ""
        Me.mobjLayoutPanel.BackColor = System.Drawing.Color.FromArgb(CInt(CByte(192)), CInt(CByte(64)), CInt(CByte(0)))
        Me.mobjLayoutPanel.Controls.Add(Me.mobjPanel)
        Me.mobjLayoutPanel.Controls.Add(Me.mobjNoButton)
        Me.mobjLayoutPanel.Controls.Add(Me.mobjYesButton)
        Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
        Me.mobjLayoutPanel.Location = New System.Drawing.Point(10, 10)
        Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
        Me.mobjLayoutPanel.Size = New System.Drawing.Size(338, 119)
        Me.mobjLayoutPanel.TabIndex = 0
        Me.mobjLayoutPanel.VisualEffect = New Gizmox.WebGUI.Forms.VisualEffects.BorderRadiusVisualEffect(15)
        ' 
        ' mobjPanel
        ' 
        Me.mobjPanel.AccessibleDescription = ""
        Me.mobjPanel.AccessibleName = ""
        Me.mobjPanel.Controls.Add(Me.mobjLabel)
        Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
        Me.mobjPanel.Location = New System.Drawing.Point(0, 0)
        Me.mobjPanel.Name = "mobjPanel"
        Me.mobjPanel.Size = New System.Drawing.Size(338, 75)
        Me.mobjPanel.TabIndex = 3
        ' 
        ' mobjLabel
        ' 
        Me.mobjLabel.AccessibleDescription = ""
        Me.mobjLabel.AccessibleName = ""
        Me.mobjLabel.BackColor = System.Drawing.Color.FromArgb(CInt(CByte(192)), CInt(CByte(64)), CInt(CByte(0)))
        Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
        Me.mobjLabel.ForeColor = System.Drawing.Color.White
        Me.mobjLabel.Location = New System.Drawing.Point(0, 0)
        Me.mobjLabel.Name = "mobjLabel"
        Me.mobjLabel.Padding = New Gizmox.WebGUI.Forms.Padding(10)
        Me.mobjLabel.Size = New System.Drawing.Size(338, 75)
        Me.mobjLabel.TabIndex = 2
        Me.mobjLabel.Text = "Please, press any of those buttons."
        Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        ' 
        ' mobjNoButton
        ' 
        Me.mobjNoButton.AccessibleDescription = ""
        Me.mobjNoButton.AccessibleName = ""
        Me.mobjNoButton.Location = New System.Drawing.Point(243, 75)
        Me.mobjNoButton.Name = "mobjNoButton"
        Me.mobjNoButton.Size = New System.Drawing.Size(75, 23)
        Me.mobjNoButton.TabIndex = 1
        Me.mobjNoButton.Text = "No"
        ' 
        ' mobjYesButton
        ' 
        Me.mobjYesButton.AccessibleDescription = ""
        Me.mobjYesButton.AccessibleName = ""
        Me.mobjYesButton.Location = New System.Drawing.Point(28, 75)
        Me.mobjYesButton.Name = "mobjYesButton"
        Me.mobjYesButton.Size = New System.Drawing.Size(75, 23)
        Me.mobjYesButton.TabIndex = 0
        Me.mobjYesButton.Text = "Yes"
        ' 
        ' CustomDialogForm
        ' 
        Me.BackColor = System.Drawing.Color.DimGray
        Me.Controls.Add(Me.mobjLayoutPanel)
        Me.DockPadding.All = 10
        Me.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable
        Me.Padding = New Gizmox.WebGUI.Forms.Padding(10)
        Me.Size = New System.Drawing.Size(358, 139)
        Me.Text = "CustomDialogForm"
        Me.VisualEffect = New Gizmox.WebGUI.Forms.VisualEffects.EmptyVisualEffect()
        Me.mobjLayoutPanel.ResumeLayout(False)
        Me.mobjPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private mobjLayoutPanel As Gizmox.WebGUI.Forms.Panel
    Private WithEvents mobjNoButton As Gizmox.WebGUI.Forms.Button
    Private WithEvents mobjYesButton As Gizmox.WebGUI.Forms.Button
    Private mobjLabel As Label
    Private mobjPanel As Gizmox.WebGUI.Forms.Panel

End Class