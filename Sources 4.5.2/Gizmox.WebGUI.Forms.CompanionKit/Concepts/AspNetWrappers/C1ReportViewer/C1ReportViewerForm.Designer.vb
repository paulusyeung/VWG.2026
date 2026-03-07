Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Namespace ComponentOneSampleAppsVB

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class C1ReportViewerForm
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
            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(C1ReportViewerForm))
            Me.mobjWrapper = New C1ReportViewerWrapper()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjRB1 = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjRB2 = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjRB3 = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjRB4 = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjRB5 = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjRB6 = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjWrapper
            ' 
            Me.mobjTLP.SetColumnSpan(Me.mobjWrapper, 2)
            Me.mobjWrapper.ControlCode = resources.GetString("mobjWrapper.ControlCode")
            Me.mobjWrapper.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjWrapper.Location = New System.Drawing.Point(0, 44)
            Me.mobjWrapper.Name = "mobjWrapper"
            Me.mobjWrapper.Size = New System.Drawing.Size(916, 265)
            Me.mobjWrapper.TabIndex = 0
            Me.mobjWrapper.Theme = "aristo"
            ' 
            ' mobjTLP
            ' 
            Me.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjTLP.Controls.Add(Me.mobjWrapper, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjRB1, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjRB2, 0, 3)
            Me.mobjTLP.Controls.Add(Me.mobjRB3, 0, 4)
            Me.mobjTLP.Controls.Add(Me.mobjRB4, 1, 2)
            Me.mobjTLP.Controls.Add(Me.mobjRB5, 1, 3)
            Me.mobjTLP.Controls.Add(Me.mobjRB6, 1, 4)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 5
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 60.0F))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjTLP.Size = New System.Drawing.Size(916, 442)
            Me.mobjTLP.TabIndex = 1
            ' 
            ' mobjInfoLabel
            ' 
            Me.mobjTLP.SetColumnSpan(Me.mobjInfoLabel, 2)
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(916, 44)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "Sample demonstrates main functionality of C1 ReportViewer:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjRB1
            ' 
            Me.mobjRB1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjRB1.Checked = True
            Me.mobjRB1.Location = New System.Drawing.Point(154, 309)
            Me.mobjRB1.Name = "mobjRB1"
            Me.mobjRB1.Size = New System.Drawing.Size(150, 44)
            Me.mobjRB1.TabIndex = 0
            Me.mobjRB1.Text = "aristo"
            Me.mobjRB1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjRB2
            ' 
            Me.mobjRB2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjRB2.Location = New System.Drawing.Point(154, 353)
            Me.mobjRB2.Name = "mobjRB2"
            Me.mobjRB2.Size = New System.Drawing.Size(150, 44)
            Me.mobjRB2.TabIndex = 0
            Me.mobjRB2.Text = "metro"
            Me.mobjRB2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjRB3
            ' 
            Me.mobjRB3.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjRB3.Location = New System.Drawing.Point(154, 397)
            Me.mobjRB3.Name = "mobjRB3"
            Me.mobjRB3.Size = New System.Drawing.Size(150, 45)
            Me.mobjRB3.TabIndex = 0
            Me.mobjRB3.Text = "cobalt"
            Me.mobjRB3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjRB4
            ' 
            Me.mobjRB4.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjRB4.Location = New System.Drawing.Point(612, 309)
            Me.mobjRB4.Name = "mobjRB4"
            Me.mobjRB4.Size = New System.Drawing.Size(150, 44)
            Me.mobjRB4.TabIndex = 0
            Me.mobjRB4.Text = "midnight"
            Me.mobjRB4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjRB5
            ' 
            Me.mobjRB5.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjRB5.Location = New System.Drawing.Point(612, 353)
            Me.mobjRB5.Name = "mobjRB5"
            Me.mobjRB5.Size = New System.Drawing.Size(150, 44)
            Me.mobjRB5.TabIndex = 0
            Me.mobjRB5.Text = "sterling"
            Me.mobjRB5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjRB6
            ' 
            Me.mobjRB6.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjRB6.Location = New System.Drawing.Point(612, 397)
            Me.mobjRB6.Name = "mobjRB6"
            Me.mobjRB6.Size = New System.Drawing.Size(150, 45)
            Me.mobjRB6.TabIndex = 0
            Me.mobjRB6.Text = "rocket"
            Me.mobjRB6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' C1ReportViewerForm
            ' 
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(391, 600)
            Me.Text = "C1ReportViewerForm"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub
        Friend WithEvents mobjWrapper As C1ReportViewerWrapper
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel
        Friend WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjRB1 As Gizmox.WebGUI.Forms.RadioButton
        Friend WithEvents mobjRB2 As Gizmox.WebGUI.Forms.RadioButton
        Friend WithEvents mobjRB3 As Gizmox.WebGUI.Forms.RadioButton
        Friend WithEvents mobjRB4 As Gizmox.WebGUI.Forms.RadioButton
        Friend WithEvents mobjRB5 As Gizmox.WebGUI.Forms.RadioButton
        Friend WithEvents mobjRB6 As Gizmox.WebGUI.Forms.RadioButton
    End Class
End Namespace
