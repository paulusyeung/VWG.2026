Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Namespace Gizmox.WebGUI.Forms.CompanionKit.WebSocketsSampleAppsVB
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ChatForm
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
            Me.mobjTLP = New TableLayoutPanel()
            Me.mobjChatTextBox = New TextBox()
            Me.mobjMessageTextBox = New TextBox()
            Me.mobjNameTextBox = New WatermarkTextBox()
            Me.mobjSendButton = New Button()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjTLP
            ' 
            Me.mobjTLP.BackColor = System.Drawing.Color.Ivory
            Me.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 70.0F))
            Me.mobjTLP.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 30.0F))
            Me.mobjTLP.Controls.Add(Me.mobjChatTextBox, 0, 1)
            Me.mobjTLP.Controls.Add(Me.mobjMessageTextBox, 0, 2)
            Me.mobjTLP.Controls.Add(Me.mobjNameTextBox, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjSendButton, 1, 2)
            Me.mobjTLP.Dock = DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 3
            Me.mobjTLP.RowStyles.Add(New RowStyle(SizeType.Percent, 15.0F))
            Me.mobjTLP.RowStyles.Add(New RowStyle(SizeType.Percent, 60.0F))
            Me.mobjTLP.RowStyles.Add(New RowStyle(SizeType.Percent, 25.0F))
            Me.mobjTLP.Size = New System.Drawing.Size(561, 432)
            Me.mobjTLP.TabIndex = 0
            ' 
            ' mobjChatTextBox
            ' 
            Me.mobjChatTextBox.Dock = DockStyle.Fill
            Me.mobjChatTextBox.Location = New System.Drawing.Point(10, 74)
            Me.mobjChatTextBox.Margin = New Padding(10)
            Me.mobjChatTextBox.Multiline = True
            Me.mobjChatTextBox.Name = "mobjChatTextBox"
            Me.mobjChatTextBox.[ReadOnly] = True
            Me.mobjChatTextBox.ScrollBars = ScrollBars.Vertical
            Me.mobjChatTextBox.Size = New System.Drawing.Size(372, 239)
            Me.mobjChatTextBox.TabIndex = 0
            ' 
            ' mobjMessageTextBox
            ' 
            Me.mobjMessageTextBox.Dock = DockStyle.Fill
            Me.mobjMessageTextBox.Location = New System.Drawing.Point(10, 333)
            Me.mobjMessageTextBox.Margin = New Padding(10)
            Me.mobjMessageTextBox.Multiline = True
            Me.mobjMessageTextBox.Name = "mobjMessageTextBox"
            Me.mobjMessageTextBox.ScrollBars = ScrollBars.Vertical
            Me.mobjMessageTextBox.Size = New System.Drawing.Size(372, 89)
            Me.mobjMessageTextBox.TabIndex = 0
            ' 
            ' mobjNameTextBox
            ' 
            Me.mobjNameTextBox.Anchor = DirectCast((AnchorStyles.Left Or AnchorStyles.Right), AnchorStyles)
            Me.mobjNameTextBox.CustomStyle = "Watermark"
            Me.mobjNameTextBox.Location = New System.Drawing.Point(10, 22)
            Me.mobjNameTextBox.Margin = New Padding(10, 3, 10, 3)
            Me.mobjNameTextBox.Message = "Enter your nickname"
            Me.mobjNameTextBox.Name = "mobjNameTextBox"
            Me.mobjNameTextBox.Size = New System.Drawing.Size(372, 30)
            Me.mobjNameTextBox.TabIndex = 0
            ' 
            ' mobjSendButton
            ' 
            Me.mobjSendButton.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.mobjSendButton.Dock = DockStyle.Fill
            Me.mobjSendButton.Location = New System.Drawing.Point(402, 333)
            Me.mobjSendButton.Margin = New Padding(10)
            Me.mobjSendButton.Name = "mobjSendButton"
            Me.mobjSendButton.Size = New System.Drawing.Size(149, 89)
            Me.mobjSendButton.TabIndex = 0
            Me.mobjSendButton.Text = "SEND"
            ' 
            ' ChatPage
            ' 
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(400, 400)
            Me.Text = "ChatPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

        Public mobjTLP As TableLayoutPanel
        Public WithEvents mobjChatTextBox As TextBox
        Public mobjMessageTextBox As TextBox
        Public mobjNameTextBox As WatermarkTextBox
        Public WithEvents mobjSendButton As Button

    End Class
End Namespace
