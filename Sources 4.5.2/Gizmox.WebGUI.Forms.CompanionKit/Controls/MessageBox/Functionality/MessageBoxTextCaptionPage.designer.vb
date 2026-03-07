Namespace CompanionKit.Controls.MessageBoxControl.Functionality

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MessageBoxTextCaptionPage
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
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjCaptionText = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjText = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjTextLbl = New Gizmox.WebGUI.Forms.Label()
            Me.mobjShowModalMask = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjShowButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjResultLbl = New Gizmox.WebGUI.Forms.Label()
            Me.mobjCaptionLbl = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjInfoLabel
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjInfoLabel, 2)
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 60)
            Me.mobjInfoLabel.TabIndex = 3
            Me.mobjInfoLabel.Text = "Enter Caption and Text to display within the MessageBox window:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjCaptionText
            '
            Me.mobjCaptionText.AllowDrag = False
            Me.mobjTLP.SetColumnSpan(Me.mobjCaptionText, 2)
            Me.mobjCaptionText.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCaptionText.Location = New System.Drawing.Point(3, 103)
            Me.mobjCaptionText.Name = "mobjCaptionText"
            Me.mobjCaptionText.Size = New System.Drawing.Size(314, 34)
            Me.mobjCaptionText.TabIndex = 4
            Me.mobjCaptionText.Text = "Caption text"
            '
            'mobjText
            '
            Me.mobjText.AllowDrag = False
            Me.mobjTLP.SetColumnSpan(Me.mobjText, 2)
            Me.mobjText.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjText.Location = New System.Drawing.Point(3, 183)
            Me.mobjText.Multiline = True
            Me.mobjText.Name = "mobjText"
            Me.mobjText.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical
            Me.mobjText.Size = New System.Drawing.Size(314, 94)
            Me.mobjText.TabIndex = 5
            Me.mobjText.Text = "Message text"
            '
            'mobjTextLbl
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjTextLbl, 2)
            Me.mobjTextLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTextLbl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.mobjTextLbl.Location = New System.Drawing.Point(0, 140)
            Me.mobjTextLbl.Name = "mobjTextLbl"
            Me.mobjTextLbl.Size = New System.Drawing.Size(320, 40)
            Me.mobjTextLbl.TabIndex = 6
            Me.mobjTextLbl.Text = "Text"
            Me.mobjTextLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjShowModalMask
            '
            Me.mobjShowModalMask.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjShowModalMask.Checked = True
            Me.mobjShowModalMask.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked
            Me.mobjShowModalMask.Location = New System.Drawing.Point(5, 295)
            Me.mobjShowModalMask.Name = "mobjShowModalMask"
            Me.mobjShowModalMask.Size = New System.Drawing.Size(150, 50)
            Me.mobjShowModalMask.TabIndex = 7
            Me.mobjShowModalMask.Text = "Show Modal Mask"
            Me.mobjShowModalMask.UseVisualStyleBackColor = True
            '
            'mobjShowButton
            '
            Me.mobjShowButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjShowButton.Location = New System.Drawing.Point(190, 295)
            Me.mobjShowButton.Name = "mobjShowButton"
            Me.mobjShowButton.Size = New System.Drawing.Size(100, 50)
            Me.mobjShowButton.TabIndex = 8
            Me.mobjShowButton.Text = "Show"
            Me.mobjShowButton.UseVisualStyleBackColor = True
            '
            'mobjResultLbl
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjResultLbl, 2)
            Me.mobjResultLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjResultLbl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.mobjResultLbl.Location = New System.Drawing.Point(0, 360)
            Me.mobjResultLbl.Name = "mobjResultLbl"
            Me.mobjResultLbl.Size = New System.Drawing.Size(320, 40)
            Me.mobjResultLbl.TabIndex = 10
            Me.mobjResultLbl.Text = "Result"
            Me.mobjResultLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjCaptionLbl
            '
            Me.mobjTLP.SetColumnSpan(Me.mobjCaptionLbl, 2)
            Me.mobjCaptionLbl.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCaptionLbl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.mobjCaptionLbl.Location = New System.Drawing.Point(0, 60)
            Me.mobjCaptionLbl.Name = "label1"
            Me.mobjCaptionLbl.Size = New System.Drawing.Size(320, 40)
            Me.mobjCaptionLbl.TabIndex = 6
            Me.mobjCaptionLbl.Text = "Caption"
            Me.mobjCaptionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjResultLbl, 0, 6)
            Me.mobjTLP.Controls.Add(Me.mobjCaptionLbl, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjShowButton, 1, 5)
            Me.mobjTLP.Controls.Add(Me.mobjCaptionText, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjShowModalMask, 0, 5)
            Me.mobjTLP.Controls.Add(Me.mobjTextLbl, 0, 3)
            Me.mobjTLP.Controls.Add(Me.mobjText, 0, 4)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 7
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 25.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 20.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 11
            '
            'MessageBoxTextCaptionPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "MessageBoxTextCaptionPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjCaptionText As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjText As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjTextLbl As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjShowModalMask As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjShowButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjResultLbl As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjCaptionLbl As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

    End Class

End Namespace