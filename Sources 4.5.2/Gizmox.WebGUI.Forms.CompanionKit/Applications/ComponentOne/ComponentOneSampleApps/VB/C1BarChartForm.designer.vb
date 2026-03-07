Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Namespace Gizmox.WebGUI.Forms.CompanionKit.ComponentOneSampleAppsVB

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class C1BarChartForm
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
            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(C1BarChartForm))
            Me.mobjWrapper = New C1BarChartWrapper()
            Me.mobjSetButton = New Button()
            Me.mobjTLP = New TableLayoutPanel()
            Me.mobjTextBox = New TextBox()
            Me.mobjInfoLabel = New Label()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjWrapper
            ' 
            Me.mobjTLP.SetColumnSpan(Me.mobjWrapper, 2)
            Me.mobjWrapper.ControlCode = resources.GetString("mobjWrapper.ControlCode")
            Me.mobjWrapper.Dock = DockStyle.Fill
            Me.mobjWrapper.Location = New System.Drawing.Point(0, 75)
            Me.mobjWrapper.Name = "mobjWrapper"
            Me.mobjWrapper.Size = New System.Drawing.Size(966, 303)
            Me.mobjWrapper.TabIndex = 0
            ' 
            ' mobjSetButton
            ' 
            Me.mobjSetButton.Anchor = AnchorStyles.None
            Me.mobjSetButton.Location = New System.Drawing.Point(674, 417)
            Me.mobjSetButton.Name = "mobjSetButton"
            Me.mobjSetButton.Size = New System.Drawing.Size(150, 50)
            Me.mobjSetButton.TabIndex = 1
            Me.mobjSetButton.Text = "Set Label Text"
            ' 
            ' mobjTLP
            ' 
            Me.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
            Me.mobjTLP.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
            Me.mobjTLP.Controls.Add(Me.mobjWrapper, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjSetButton, 1, 2)
            Me.mobjTLP.Controls.Add(Me.mobjTextBox, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Dock = DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 3
            Me.mobjTLP.RowStyles.Add(New RowStyle(SizeType.Percent, 15.0F))
            Me.mobjTLP.RowStyles.Add(New RowStyle(SizeType.Percent, 60.0F))
            Me.mobjTLP.RowStyles.Add(New RowStyle(SizeType.Percent, 25.0F))
            Me.mobjTLP.Size = New System.Drawing.Size(966, 506)
            Me.mobjTLP.TabIndex = 2
            ' 
            ' mobjTextBox
            ' 
            Me.mobjTextBox.Anchor = AnchorStyles.None
            Me.mobjTextBox.Location = New System.Drawing.Point(166, 429)
            Me.mobjTextBox.Name = "mobjTextBox"
            Me.mobjTextBox.Size = New System.Drawing.Size(150, 25)
            Me.mobjTextBox.TabIndex = 0
            Me.mobjTextBox.Text = "new text..."
            ' 
            ' mobjInfoLabel
            ' 
            Me.mobjTLP.SetColumnSpan(Me.mobjInfoLabel, 2)
            Me.mobjInfoLabel.Dock = DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(966, 75)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "Sample demonstrates main functionality of C1 BarChart:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' C1BarChartForm
            ' 
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(966, 600)
            Me.Text = "C1BarChartForm"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents mobjWrapper As C1BarChartWrapper
        Friend WithEvents mobjSetButton As Button
        Friend WithEvents mobjTLP As TableLayoutPanel
        Friend WithEvents mobjTextBox As TextBox
        Friend WithEvents mobjInfoLabel As Label
    End Class

End Namespace