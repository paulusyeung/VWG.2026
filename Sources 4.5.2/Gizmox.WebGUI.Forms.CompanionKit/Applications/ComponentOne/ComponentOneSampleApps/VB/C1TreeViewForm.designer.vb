Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Namespace Gizmox.WebGUI.Forms.CompanionKit.ComponentOneSampleAppsVB

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class C1TreeViewForm
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
            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(C1TreeViewForm))
            Me.mobjWrapper = New C1TreeViewWrapper()
            Me.mobjCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjWrapper
            ' 
            Me.mobjTLP.SetColumnSpan(Me.mobjWrapper, 2)
            Me.mobjWrapper.ControlCode = resources.GetString("mobjWrapper.ControlCode")
            Me.mobjWrapper.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjWrapper.Location = New System.Drawing.Point(0, 71)
            Me.mobjWrapper.Name = "mobjWrapper"
            Me.mobjWrapper.Size = New System.Drawing.Size(753, 310)
            Me.mobjWrapper.TabIndex = 1
            ' 
            ' mobjCheckBox
            ' 
            Me.mobjCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjCheckBox.Location = New System.Drawing.Point(113, 404)
            Me.mobjCheckBox.Name = "mobjCheckBox"
            Me.mobjCheckBox.Size = New System.Drawing.Size(150, 50)
            Me.mobjCheckBox.TabIndex = 1
            Me.mobjCheckBox.Checked = True
            Me.mobjCheckBox.Text = "Show Check Boxes"
            Me.mobjCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjTLP
            ' 
            Me.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjWrapper, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjCheckBox, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjLabel, 1, 2)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 3
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 65.0F))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0F))
            Me.mobjTLP.Size = New System.Drawing.Size(753, 478)
            Me.mobjTLP.TabIndex = 2
            ' 
            ' mobjInfoLabel
            ' 
            Me.mobjTLP.SetColumnSpan(Me.mobjInfoLabel, 2)
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(753, 71)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "Sample demonstrates main functionality of C1 TreeView:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjLabel
            ' 
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel.Location = New System.Drawing.Point(376, 381)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(377, 97)
            Me.mobjLabel.TabIndex = 0
            Me.mobjLabel.Text = "Selected Nodes"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' TreeViewWrapperForm
            ' 
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(753, 600)
            Me.Text = "TrteeViewWrapperForm"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub
        Friend WithEvents mobjCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Friend WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel
        Friend WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjLabel As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjWrapper As C1TreeViewWrapper
    End Class

End Namespace