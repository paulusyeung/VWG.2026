Namespace CompanionKit.Controls.TabControl.Appearance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class TextWithImagePage
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
            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(TextWithImagePage))
            Me.mobjDemoTabControl = New Gizmox.WebGUI.Forms.TabControl()
            Me.mobjVWGTabPage = New Gizmox.WebGUI.Forms.TabPage()
            Me.mobjTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjPictureBox3 = New Gizmox.WebGUI.Forms.PictureBox()
            Me.mobjSeaTabPage = New Gizmox.WebGUI.Forms.TabPage()
            Me.mobjSeaPicture = New Gizmox.WebGUI.Forms.PictureBox()
            Me.mobjStoneTabPage = New Gizmox.WebGUI.Forms.TabPage()
            Me.mobjPictureBox1 = New Gizmox.WebGUI.Forms.PictureBox()
            Me.mobjViewTabPage = New Gizmox.WebGUI.Forms.TabPage()
            Me.mobjPictureBox2 = New Gizmox.WebGUI.Forms.PictureBox()
            Me.mobjDescriptionLabel = New Gizmox.WebGUI.Forms.Label()
            DirectCast(Me.mobjDemoTabControl, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjDemoTabControl.SuspendLayout()
            Me.mobjVWGTabPage.SuspendLayout()
            DirectCast(Me.mobjPictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjSeaTabPage.SuspendLayout()
            DirectCast(Me.mobjSeaPicture, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjStoneTabPage.SuspendLayout()
            DirectCast(Me.mobjPictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjViewTabPage.SuspendLayout()
            DirectCast(Me.mobjPictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' mobjDemoTabControl
            ' 
            Me.mobjDemoTabControl.Controls.Add(Me.mobjVWGTabPage)
            Me.mobjDemoTabControl.Controls.Add(Me.mobjSeaTabPage)
            Me.mobjDemoTabControl.Controls.Add(Me.mobjStoneTabPage)
            Me.mobjDemoTabControl.Controls.Add(Me.mobjViewTabPage)
            Me.mobjDemoTabControl.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjDemoTabControl.Location = New System.Drawing.Point(0, 40)
            Me.mobjDemoTabControl.Name = "mobjDemoTabControl"
            Me.mobjDemoTabControl.SelectedIndex = 0
            Me.mobjDemoTabControl.Size = New System.Drawing.Size(391, 266)
            Me.mobjDemoTabControl.TabIndex = 0
            ' 
            ' mobjVWGTabPage
            ' 
            Me.mobjVWGTabPage.Controls.Add(Me.mobjTextBox)
            Me.mobjVWGTabPage.Controls.Add(Me.mobjPictureBox3)
            Me.mobjVWGTabPage.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjVWGTabPage.Location = New System.Drawing.Point(0, 0)
            Me.mobjVWGTabPage.Name = "mobjVWGTabPage"
            Me.mobjVWGTabPage.Size = New System.Drawing.Size(383, 279)
            Me.mobjVWGTabPage.TabIndex = 0
            Me.mobjVWGTabPage.Text = "Visual WebGui"
            ' 
            ' mobjTextBox
            ' 
            Me.mobjTextBox.AllowDrag = False
            Me.mobjTextBox.Anchor = DirectCast((((Gizmox.WebGUI.Forms.AnchorStyles.Top Or Gizmox.WebGUI.Forms.AnchorStyles.Bottom) Or Gizmox.WebGUI.Forms.AnchorStyles.Left) Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjTextBox.BackColor = System.Drawing.Color.Transparent
            Me.mobjTextBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None
            Me.mobjTextBox.Location = New System.Drawing.Point(6, 95)
            Me.mobjTextBox.Multiline = True
            Me.mobjTextBox.Name = "mobjTextBox"
            Me.mobjTextBox.[ReadOnly] = True
            Me.mobjTextBox.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical
            Me.mobjTextBox.Size = New System.Drawing.Size(374, 142)
            Me.mobjTextBox.TabIndex = 2
            ' 
            ' mobjPictureBox3
            ' 
            Me.mobjPictureBox3.Anchor = DirectCast((((Gizmox.WebGUI.Forms.AnchorStyles.Top Or Gizmox.WebGUI.Forms.AnchorStyles.Bottom) Or Gizmox.WebGUI.Forms.AnchorStyles.Left) Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjPictureBox3.Image = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjPictureBox3.Image"))
            Me.mobjPictureBox3.Location = New System.Drawing.Point(83, 17)
            Me.mobjPictureBox3.Name = "mobjPictureBox3"
            Me.mobjPictureBox3.Size = New System.Drawing.Size(196, 73)
            Me.mobjPictureBox3.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage
            Me.mobjPictureBox3.TabIndex = 0
            Me.mobjPictureBox3.TabStop = False
            ' 
            ' mobjSeaTabPage
            ' 
            Me.mobjSeaTabPage.Controls.Add(Me.mobjSeaPicture)
            Me.mobjSeaTabPage.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSeaTabPage.Location = New System.Drawing.Point(4, 22)
            Me.mobjSeaTabPage.Name = "mobjSeaTabPage"
            Me.mobjSeaTabPage.Size = New System.Drawing.Size(383, 279)
            Me.mobjSeaTabPage.TabIndex = 1
            Me.mobjSeaTabPage.Text = "Sea"
            ' 
            ' mobjSeaPicture
            ' 
            Me.mobjSeaPicture.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSeaPicture.Image = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjSeaPicture.Image"))
            Me.mobjSeaPicture.Location = New System.Drawing.Point(3, 3)
            Me.mobjSeaPicture.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.mobjSeaPicture.Name = "mobjSeaPicture"
            Me.mobjSeaPicture.Size = New System.Drawing.Size(383, 279)
            Me.mobjSeaPicture.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage
            Me.mobjSeaPicture.TabIndex = 0
            Me.mobjSeaPicture.TabStop = False
            ' 
            ' mobjStoneTabPage
            ' 
            Me.mobjStoneTabPage.Controls.Add(Me.mobjPictureBox1)
            Me.mobjStoneTabPage.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjStoneTabPage.Location = New System.Drawing.Point(4, 22)
            Me.mobjStoneTabPage.Name = "mobjStoneTabPage"
            Me.mobjStoneTabPage.Size = New System.Drawing.Size(383, 279)
            Me.mobjStoneTabPage.TabIndex = 2
            Me.mobjStoneTabPage.Text = "Stone"
            ' 
            ' mobjPictureBox1
            ' 
            Me.mobjPictureBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPictureBox1.Image = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjPictureBox1.Image"))
            Me.mobjPictureBox1.Location = New System.Drawing.Point(3, 3)
            Me.mobjPictureBox1.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.mobjPictureBox1.Name = "mobjPictureBox1"
            Me.mobjPictureBox1.Size = New System.Drawing.Size(383, 279)
            Me.mobjPictureBox1.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage
            Me.mobjPictureBox1.TabIndex = 0
            Me.mobjPictureBox1.TabStop = False
            ' 
            ' mobjViewTabPage
            ' 
            Me.mobjViewTabPage.Controls.Add(Me.mobjPictureBox2)
            Me.mobjViewTabPage.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjViewTabPage.Location = New System.Drawing.Point(0, 0)
            Me.mobjViewTabPage.Name = "mobjViewTabPage"
            Me.mobjViewTabPage.Size = New System.Drawing.Size(383, 240)
            Me.mobjViewTabPage.TabIndex = 3
            Me.mobjViewTabPage.Text = "View"
            ' 
            ' mobjPictureBox2
            ' 
            Me.mobjPictureBox2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPictureBox2.Image = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjPictureBox2.Image"))
            Me.mobjPictureBox2.Location = New System.Drawing.Point(0, 0)
            Me.mobjPictureBox2.Margin = New Gizmox.WebGUI.Forms.Padding(10)
            Me.mobjPictureBox2.Name = "mobjPictureBox2"
            Me.mobjPictureBox2.Size = New System.Drawing.Size(383, 240)
            Me.mobjPictureBox2.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage
            Me.mobjPictureBox2.TabIndex = 0
            Me.mobjPictureBox2.TabStop = False
            ' 
            ' mobjDescriptionLabel
            ' 
            Me.mobjDescriptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDescriptionLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjDescriptionLabel.Name = "mobjDescriptionLabel"
            Me.mobjDescriptionLabel.Size = New System.Drawing.Size(391, 40)
            Me.mobjDescriptionLabel.TabIndex = 1
            Me.mobjDescriptionLabel.Text = "TabControl demonstrates how to use text and image in a TabPage"
            Me.mobjDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' TextWithImagePage
            ' 
            Me.Controls.Add(Me.mobjDescriptionLabel)
            Me.Controls.Add(Me.mobjDemoTabControl)
            Me.Size = New System.Drawing.Size(391, 306)
            Me.Text = "TextWithImagePage"
            DirectCast(Me.mobjDemoTabControl, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjDemoTabControl.ResumeLayout(False)
            Me.mobjVWGTabPage.ResumeLayout(False)
            DirectCast(Me.mobjPictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjSeaTabPage.ResumeLayout(False)
            DirectCast(Me.mobjSeaPicture, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjStoneTabPage.ResumeLayout(False)
            DirectCast(Me.mobjPictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjViewTabPage.ResumeLayout(False)
            DirectCast(Me.mobjPictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Private mobjDemoTabControl As Global.Gizmox.WebGUI.Forms.TabControl
        Private mobjSeaTabPage As TabPage
        Private mobjStoneTabPage As TabPage
        Private mobjViewTabPage As TabPage
        Private mobjVWGTabPage As TabPage
        Private mobjSeaPicture As Global.Gizmox.WebGUI.Forms.PictureBox
        Private mobjPictureBox1 As Global.Gizmox.WebGUI.Forms.PictureBox
        Private mobjPictureBox2 As Global.Gizmox.WebGUI.Forms.PictureBox
        Private mobjPictureBox3 As Global.Gizmox.WebGUI.Forms.PictureBox
        Private mobjDescriptionLabel As Label
        Private mobjTextBox As Gizmox.WebGUI.Forms.TextBox

	End Class

End Namespace