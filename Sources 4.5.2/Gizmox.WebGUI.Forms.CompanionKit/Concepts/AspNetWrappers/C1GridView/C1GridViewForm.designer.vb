Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Namespace ComponentOneSampleAppsVB

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class C1GridViewForm
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
            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(C1GridViewForm))
            Me.mobjWrapper = New C1GridViewWrapper()
            Me.mobjSelectedPageIndex = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjNUD = New Gizmox.WebGUI.Forms.NumericUpDown()
            Me.mobjShowFilterRow = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjAllowPaging = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjTLP.SuspendLayout()
            DirectCast(Me.mobjNUD, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' mobjGridViewWrapper
            ' 
            Me.mobjTLP.SetColumnSpan(Me.mobjWrapper, 2)
            Me.mobjWrapper.ControlCode = resources.GetString("mobjGridViewWrapper.ControlCode")
            Me.mobjWrapper.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjWrapper.Location = New System.Drawing.Point(0, 74)
            Me.mobjWrapper.Name = "mobjGridViewWrapper"
            Me.mobjWrapper.Size = New System.Drawing.Size(997, 273)
            Me.mobjWrapper.TabIndex = 0
            Me.mobjWrapper.PageSize = 10
            ' 
            ' mobjSelectedPageIndex
            ' 
            Me.mobjSelectedPageIndex.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSelectedPageIndex.Location = New System.Drawing.Point(498, 421)
            Me.mobjSelectedPageIndex.Name = "mobjSelectedPageIndex"
            Me.mobjSelectedPageIndex.Size = New System.Drawing.Size(499, 76)
            Me.mobjSelectedPageIndex.TabIndex = 2
            Me.mobjSelectedPageIndex.Text = "Selected Page Index: "
            Me.mobjSelectedPageIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjTLP
            ' 
            Me.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjTLP.Controls.Add(Me.mobjSelectedPageIndex, 1, 3)
            Me.mobjTLP.Controls.Add(Me.mobjWrapper, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjNUD, 1, 2)
            Me.mobjTLP.Controls.Add(Me.mobjShowFilterRow, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjAllowPaging, 0, 3)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 4
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 55.0F))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjTLP.Size = New System.Drawing.Size(997, 497)
            Me.mobjTLP.TabIndex = 3
            ' 
            ' mobjInfoLabel
            ' 
            Me.mobjTLP.SetColumnSpan(Me.mobjInfoLabel, 2)
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(997, 74)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "Sample demonstrates main functionality of C1 GridView:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjNUD
            ' 
            Me.mobjNUD.Anchor = DirectCast((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjNUD.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange
            Me.mobjNUD.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None
            Me.mobjNUD.CurrentValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.mobjNUD.Location = New System.Drawing.Point(508, 373)
            Me.mobjNUD.Margin = New Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0)
            Me.mobjNUD.Name = "mobjNUD"
            Me.mobjNUD.Size = New System.Drawing.Size(479, 17)
            Me.mobjNUD.TabIndex = 0
            Me.mobjNUD.Minimum = 1
            ' 
            ' mobjShowFilterRow
            ' 
            Me.mobjShowFilterRow.Anchor = DirectCast((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjShowFilterRow.Checked = True
            Me.mobjShowFilterRow.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjShowFilterRow.Location = New System.Drawing.Point(10, 372)
            Me.mobjShowFilterRow.Margin = New Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0)
            Me.mobjShowFilterRow.Name = "mobjShowFilterRow"
            Me.mobjShowFilterRow.Size = New System.Drawing.Size(478, 23)
            Me.mobjShowFilterRow.TabIndex = 0
            Me.mobjShowFilterRow.Text = "Show Filter Row"
            ' 
            ' mobjAllowPaging
            ' 
            Me.mobjAllowPaging.Anchor = DirectCast((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjAllowPaging.Checked = True
            Me.mobjAllowPaging.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjAllowPaging.Location = New System.Drawing.Point(10, 447)
            Me.mobjAllowPaging.Margin = New Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0)
            Me.mobjAllowPaging.Name = "mobjAllowPaging"
            Me.mobjAllowPaging.Size = New System.Drawing.Size(478, 23)
            Me.mobjAllowPaging.TabIndex = 0
            Me.mobjAllowPaging.Text = "Allow Paging"
            ' 
            ' C1GridViewPage
            ' 
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(391, 600)
            Me.Text = "C1GridViewPage"
            Me.mobjTLP.ResumeLayout(False)
            DirectCast(Me.mobjNUD, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub
        Friend WithEvents mobjWrapper As C1GridViewWrapper
        Friend WithEvents mobjSelectedPageIndex As Label
        Friend WithEvents mobjTLP As TableLayoutPanel
        Friend WithEvents mobjInfoLabel As Label
        Friend WithEvents mobjNUD As NumericUpDown
        Friend WithEvents mobjShowFilterRow As CheckBox
        Friend WithEvents mobjAllowPaging As CheckBox
    End Class

End Namespace