Namespace CompanionKit.Controls.HeaderedPanel.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class HeaderedPanelIconPropertyPage
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
            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(HeaderedPanelIconPropertyPage))
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjHeaderedPanel = New Gizmox.WebGUI.Forms.HeaderedPanel()
            Me.mobjRadioButton1 = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjRadioButton2 = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjRadioButton3 = New Gizmox.WebGUI.Forms.RadioButton()
            Me.mobjHeaderedPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjLabel
            ' 
            Me.mobjLabel.AutoSize = True
            Me.mobjLabel.Location = New System.Drawing.Point(63, 93)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(35, 13)
            Me.mobjLabel.TabIndex = 0
            Me.mobjLabel.Text = "Panel content"
            ' 
            ' mobjHeaderedPanel
            ' 
            Me.mobjHeaderedPanel.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjHeaderedPanel.Controls.Add(Me.mobjLabel)
            Me.mobjHeaderedPanel.CustomStyle = "HeaderedPanel"
            Me.mobjHeaderedPanel.Location = New System.Drawing.Point(11, 15)
            Me.mobjHeaderedPanel.Name = "mobjHeaderedPanel"
            Me.mobjHeaderedPanel.Size = New System.Drawing.Size(200, 200)
            Me.mobjHeaderedPanel.TabIndex = 0
            ' 
            ' mobjRadioButton1
            ' 
            Me.mobjRadioButton1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjRadioButton1.Image = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjRadioButton1.Image"))
            Me.mobjRadioButton1.Location = New System.Drawing.Point(223, 15)
            Me.mobjRadioButton1.Name = "mobjRadioButton1"
            Me.mobjRadioButton1.Size = New System.Drawing.Size(120, 40)
            Me.mobjRadioButton1.TabIndex = 1
            Me.mobjRadioButton1.Text = "Image 1"
            Me.mobjRadioButton1.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageBeforeText
            Me.mobjRadioButton1.UseVisualStyleBackColor = True
            ' 
            ' mobjRadioButton2
            ' 
            Me.mobjRadioButton2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjRadioButton2.Image = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjRadioButton2.Image"))
            Me.mobjRadioButton2.Location = New System.Drawing.Point(223, 82)
            Me.mobjRadioButton2.Name = "mobjRadioButton2"
            Me.mobjRadioButton2.Size = New System.Drawing.Size(120, 40)
            Me.mobjRadioButton2.TabIndex = 1
            Me.mobjRadioButton2.Text = "Image 2"
            Me.mobjRadioButton2.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageBeforeText
            ' 
            ' mobjRadioButton3
            ' 
            Me.mobjRadioButton3.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjRadioButton3.Image = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("mobjRadioButton3.Image"))
            Me.mobjRadioButton3.Location = New System.Drawing.Point(223, 143)
            Me.mobjRadioButton3.Name = "mobjRadioButton3"
            Me.mobjRadioButton3.Size = New System.Drawing.Size(120, 40)
            Me.mobjRadioButton3.TabIndex = 1
            Me.mobjRadioButton3.Text = "Image 3"
            Me.mobjRadioButton3.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageBeforeText
            ' 
            ' HeaderedPanelIconPropertyPage
            ' 
            Me.Controls.Add(Me.mobjRadioButton3)
            Me.Controls.Add(Me.mobjRadioButton2)
            Me.Controls.Add(Me.mobjRadioButton1)
            Me.Controls.Add(Me.mobjHeaderedPanel)
            Me.Size = New System.Drawing.Size(372, 290)
            Me.Text = "HeaderedPanelIconPropertyPage"
            Me.mobjHeaderedPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjLabel As Gizmox.WebGUI.Forms.Label
        Private mobjHeaderedPanel As Gizmox.WebGUI.Forms.HeaderedPanel
        Private WithEvents mobjRadioButton1 As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjRadioButton2 As Gizmox.WebGUI.Forms.RadioButton
        Private WithEvents mobjRadioButton3 As Gizmox.WebGUI.Forms.RadioButton


	End Class

End Namespace