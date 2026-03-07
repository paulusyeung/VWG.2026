Namespace CompanionKit.Controls.FlashBox.Programming

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ProvideParametersPage
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
            Me.demoFlashBox = New Gizmox.WebGUI.Forms.Hosts.FlashBox
            Me.SuspendLayout()
            '
            'demoFlashBox
            '
            Me.demoFlashBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.demoFlashBox.CodeBase = "http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0" & _
                ",0"
            Me.demoFlashBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.demoFlashBox.Location = New System.Drawing.Point(0, 0)
            Me.demoFlashBox.Name = "demoFlashBox"
            Me.demoFlashBox.Parameters.Add("src", "../../../../../../../Resources/Flash/FC_2_3_Column3D.swf")
            Me.demoFlashBox.Parameters.Add("FlashVars", "&dataURL=../../../../../../../Resources/Flash/FC_2_3_DATA.xml")
            Me.demoFlashBox.Parameters.Add("quality", "high")
            Me.demoFlashBox.Size = New System.Drawing.Size(391, 306)
            Me.demoFlashBox.TabIndex = 0
            '
            'ProvideParametersPage
            '
            Me.Controls.Add(Me.demoFlashBox)
            Me.Size = New System.Drawing.Size(391, 450)
            Me.Text = "ProvideParametersPage"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents demoFlashBox As Gizmox.WebGUI.Forms.Hosts.FlashBox

	End Class

End Namespace