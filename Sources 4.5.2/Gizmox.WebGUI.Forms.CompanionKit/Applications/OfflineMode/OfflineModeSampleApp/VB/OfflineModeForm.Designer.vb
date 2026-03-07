Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Namespace Gizmox.WebGUI.Forms.CompanionKit.OfflineModeSampleAppVB
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class OfflineModeForm
        Inherits Form

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
        'It can be modified using the Visual webGui Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OfflineModeForm))
            Me.mobjStatusStrip = New StatusStrip()
            Me.mobjToolStripStatusLabel = New ToolStripStatusLabel()
            Me.mobjLayoutPanel = New TableLayoutPanel()
            Me.mobjLogTextBox = New TextBox()
            Me.mobjPictureBox = New PictureBox()
            Me.mobjLabel = New Label()
            Me.mobjLayoutPanel.SuspendLayout()
            CType(Me.mobjPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'mobjStatusStrip
            '
            Me.mobjStatusStrip.BackColor = System.Drawing.Color.Green
            Me.mobjStatusStrip.Dock = DockStyle.Bottom
            Me.mobjStatusStrip.DockPadding.Left = 1
            Me.mobjStatusStrip.DockPadding.Right = 14
            Me.mobjStatusStrip.Items.AddRange(New ToolStripItem() {Me.mobjToolStripStatusLabel})
            Me.mobjStatusStrip.Location = New System.Drawing.Point(0, 499)
            Me.mobjStatusStrip.MinimumSize = New System.Drawing.Size(0, 50)
            Me.mobjStatusStrip.Name = "mobjStatusStrip"
            Me.mobjStatusStrip.Size = New System.Drawing.Size(882, 50)
            Me.mobjStatusStrip.TabIndex = 0
            Me.mobjStatusStrip.Text = "StatusStrip"
            '
            'mobjToolStripStatusLabel
            '
            Me.mobjToolStripStatusLabel.ClientId = "statusStripLabel"
            Me.mobjToolStripStatusLabel.Margin = New Padding(0, 1, 0, 2)
            Me.mobjToolStripStatusLabel.Name = "mobjToolStripStatusLabel"
            Me.mobjToolStripStatusLabel.Size = New System.Drawing.Size(37, 13)
            Me.mobjToolStripStatusLabel.Text = "Online"
            '
            'mobjLayoutPanel
            '
            Me.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.mobjLayoutPanel.ColumnCount = 5
            Me.mobjLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20.0!))
            Me.mobjLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
            Me.mobjLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 128.0!))
            Me.mobjLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
            Me.mobjLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20.0!))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjLogTextBox, 1, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPictureBox, 2, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjLabel, 1, 3)
            Me.mobjLayoutPanel.Dock = DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 6
            Me.mobjLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 20.0!))
            Me.mobjLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 128.0!))
            Me.mobjLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0!))
            Me.mobjLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 40.0!))
            Me.mobjLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 200.0!))
            Me.mobjLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0!))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(882, 471)
            Me.mobjLayoutPanel.TabIndex = 1
            '
            'mobjLogTextBox
            '
            Me.mobjLogTextBox.ClientId = "textBox"
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjLogTextBox, 3)
            Me.mobjLogTextBox.Dock = DockStyle.Fill
            Me.mobjLogTextBox.Location = New System.Drawing.Point(23, 232)
            Me.mobjLogTextBox.Multiline = True
            Me.mobjLogTextBox.Name = "mobjLogTextBox"
            Me.mobjLogTextBox.ReadOnly = True
            Me.mobjLogTextBox.ScrollBars = ScrollBars.Vertical
            Me.mobjLogTextBox.Size = New System.Drawing.Size(836, 194)
            Me.mobjLogTextBox.TabIndex = 0
            '
            'mobjPictureBox
            '
            Me.mobjPictureBox.ClientId = "pictureBox"
            Me.mobjPictureBox.Dock = DockStyle.Fill
            Me.mobjPictureBox.Image = New Common.Resources.ImageResourceHandle(resources.GetString("mobjPictureBox.Image"))
            Me.mobjPictureBox.Location = New System.Drawing.Point(377, 20)
            Me.mobjPictureBox.Name = "mobjPictureBox"
            Me.mobjPictureBox.Size = New System.Drawing.Size(128, 128)
            Me.mobjPictureBox.TabIndex = 0
            Me.mobjPictureBox.TabStop = False
            '
            'mobjLabel
            '
            Me.mobjLabel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjLabel, 3)
            Me.mobjLabel.Dock = DockStyle.Fill
            Me.mobjLabel.Location = New System.Drawing.Point(20, 189)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(842, 40)
            Me.mobjLabel.TabIndex = 0
            Me.mobjLabel.Text = "Log :"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'OfflineModeForm
            '
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Controls.Add(Me.mobjStatusStrip)
            Me.Size = New System.Drawing.Size(882, 521)
            Me.Text = "OfflineModePage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            CType(Me.mobjPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Private mobjStatusStrip As StatusStrip
        Private mobjToolStripStatusLabel As ToolStripStatusLabel
        Private mobjLayoutPanel As TableLayoutPanel
        Private mobjPictureBox As PictureBox
        Private mobjLogTextBox As TextBox
        Private mobjLabel As Label

    End Class
End Namespace
