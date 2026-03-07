Namespace CompanionKit.Controls.GroupBox.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class BackgroundPage
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
            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(BackgroundPage))
            Me.mobjGroupColor = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjSnow = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjMoccasin = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjTransparent = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjPictureBox = New Gizmox.WebGUI.Forms.PictureBox()
            Me.mobjGroupColor.SuspendLayout()
            DirectCast(Me.mobjPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' mobjGroupColor
            ' 
            Me.mobjGroupColor.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjGroupColor.Controls.Add(Me.mobjSnow)
            Me.mobjGroupColor.Controls.Add(Me.mobjMoccasin)
            Me.mobjGroupColor.Controls.Add(Me.mobjTransparent)
            Me.mobjGroupColor.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGroupColor.Location = New System.Drawing.Point(70, 50)
            Me.mobjGroupColor.Name = "mobjGroupColor"
            Me.mobjGroupColor.Size = New System.Drawing.Size(267, 183)
            Me.mobjGroupColor.TabIndex = 0
            Me.mobjGroupColor.TabStop = False
            Me.mobjGroupColor.Text = "Background color"
            ' 
            ' mobjSnow
            ' 
            Me.mobjSnow.AutoSize = True
            Me.mobjSnow.Location = New System.Drawing.Point(15, 75)
            Me.mobjSnow.Name = "mobjSnow"
            Me.mobjSnow.Size = New System.Drawing.Size(221, 18)
            Me.mobjSnow.TabIndex = 0
            Me.mobjSnow.Text = "Snow"
            ' 
            ' mobjMoccasin
            ' 
            Me.mobjMoccasin.AutoSize = True
            Me.mobjMoccasin.Location = New System.Drawing.Point(15, 51)
            Me.mobjMoccasin.Name = "mobjMoccasin"
            Me.mobjMoccasin.Size = New System.Drawing.Size(221, 18)
            Me.mobjMoccasin.TabIndex = 0
            Me.mobjMoccasin.Text = "Moccasin"
            ' 
            ' mobjTransparent
            ' 
            Me.mobjTransparent.AutoSize = True
            Me.mobjTransparent.Checked = True
            Me.mobjTransparent.Location = New System.Drawing.Point(15, 27)
            Me.mobjTransparent.Name = "mobjTransparent"
            Me.mobjTransparent.Size = New System.Drawing.Size(221, 18)
            Me.mobjTransparent.TabIndex = 0
            Me.mobjTransparent.Text = "Transparent"
            Me.mobjTransparent.UseVisualStyleBackColor = True
            ' 
            ' mobjPictureBox
            ' 
            Me.mobjPictureBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjPictureBox.BorderWidth = New Gizmox.WebGUI.Forms.BorderWidth(0)
            Me.mobjPictureBox.Image = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjPictureBox.Image"))
            Me.mobjPictureBox.Location = New System.Drawing.Point(82, 154)
            Me.mobjPictureBox.Name = "mobjPictureBox"
            Me.mobjPictureBox.Size = New System.Drawing.Size(243, 70)
            Me.mobjPictureBox.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.AutoSize
            Me.mobjPictureBox.TabIndex = 2
            Me.mobjPictureBox.TabStop = False
            ' 
            ' BackgroundPage
            ' 
            Me.Controls.Add(Me.mobjGroupColor)
            Me.Controls.Add(Me.mobjPictureBox)
            Me.Name = "BackgoundPage"
            Me.Size = New System.Drawing.Size(400, 291)
            Me.Text = "UserControl1"
            Me.mobjGroupColor.ResumeLayout(False)
            DirectCast(Me.mobjPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Private mobjGroupColor As Gizmox.WebGUI.Forms.GroupBox
        Private WithEvents mobjSnow As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjMoccasin As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjTransparent As Gizmox.WebGUI.Forms.RadioButton
        Private mobjPictureBox As Gizmox.WebGUI.Forms.PictureBox

	End Class

End Namespace