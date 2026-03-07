Namespace CompanionKit.Controls.MessageBoxControl.Functionality

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MessageBoxButtonsPage
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
            Me.mobjMessageBoxButtonsCB = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjShowButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjShowModalMask = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjResultLbl = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjMessageBoxButtonsCB
            '
            Me.mobjMessageBoxButtonsCB.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjMessageBoxButtonsCB.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjMessageBoxButtonsCB.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjMessageBoxButtonsCB.FormattingEnabled = True
            Me.mobjMessageBoxButtonsCB.Location = New System.Drawing.Point(160, 109)
            Me.mobjMessageBoxButtonsCB.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjMessageBoxButtonsCB.Name = "mobjMessageBoxButtonsCB"
            Me.mobjMessageBoxButtonsCB.Size = New System.Drawing.Size(160, 25)
            Me.mobjMessageBoxButtonsCB.TabIndex = 0
            '
            'mobjLabel
            '
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel.Location = New System.Drawing.Point(0, 80)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjLabel.Size = New System.Drawing.Size(160, 80)
            Me.mobjLabel.TabIndex = 1
            Me.mobjLabel.Text = "MessageBox buttons"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjShowButton
            '
            Me.mobjShowButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjTLP.SetColumnSpan(Me.mobjShowButton, 2)
            Me.mobjShowButton.Location = New System.Drawing.Point(85, 255)
            Me.mobjShowButton.Name = "mobjShowButton"
            Me.mobjShowButton.Size = New System.Drawing.Size(150, 50)
            Me.mobjShowButton.TabIndex = 2
            Me.mobjShowButton.Text = "Show"
            Me.mobjShowButton.UseVisualStyleBackColor = True
            '
            'mobjInfoLabel
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjInfoLabel, 2)
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 80)
            Me.mobjInfoLabel.TabIndex = 3
            Me.mobjInfoLabel.Text = "Choose buttons to show within the MessageBox window:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjShowModalMask
            '
            Me.mobjShowModalMask.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjShowModalMask.Checked = True
            Me.mobjShowModalMask.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjTLP.SetColumnSpan(Me.mobjShowModalMask, 2)
            Me.mobjShowModalMask.Location = New System.Drawing.Point(85, 175)
            Me.mobjShowModalMask.Name = "mobjShowModalMask"
            Me.mobjShowModalMask.Size = New System.Drawing.Size(150, 50)
            Me.mobjShowModalMask.TabIndex = 4
            Me.mobjShowModalMask.Text = "Show Modal Mask"
            Me.mobjShowModalMask.UseVisualStyleBackColor = True
            '
            'mobjResultLbl
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjResultLbl, 2)
            Me.mobjResultLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjResultLbl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.mobjResultLbl.Location = New System.Drawing.Point(0, 320)
            Me.mobjResultLbl.Name = "mobjResultLbl"
            Me.mobjResultLbl.Size = New System.Drawing.Size(320, 80)
            Me.mobjResultLbl.TabIndex = 10
            Me.mobjResultLbl.Text = "Result"
            Me.mobjResultLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjResultLbl, 0, 4)
            Me.mobjTLP.Controls.Add(Me.mobjLabel, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjShowButton, 0, 3)
            Me.mobjTLP.Controls.Add(Me.mobjShowModalMask, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjMessageBoxButtonsCB, 1, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 5
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 11
            '
            'MessageBoxButtonsPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "MessageBoxButtonsPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjMessageBoxButtonsCB As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents mobjLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjShowButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjShowModalMask As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjResultLbl As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

    End Class

End Namespace