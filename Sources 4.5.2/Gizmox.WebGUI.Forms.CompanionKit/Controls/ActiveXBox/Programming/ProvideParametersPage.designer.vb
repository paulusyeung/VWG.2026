Namespace CompanionKit.Controls.ActiveXBox.Programming

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProvideParametersPage))
            Me.demoActiveXBox = New Gizmox.WebGUI.Forms.Hosts.ActiveXBox
            Me.SuspendLayout()
            '
            'demoActiveXBox
            '
            Me.demoActiveXBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.demoActiveXBox.ClassId = "clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"
            Me.demoActiveXBox.CodeBase = "http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0" & _
                ",0"
            Me.demoActiveXBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.demoActiveXBox.Location = New System.Drawing.Point(0, 0)
            Me.demoActiveXBox.Name = "demoActiveXBox"
            Me.demoActiveXBox.Parameters.Add("src", "../../../../../../Resources/Flash/FC_2_3_Area2D.swf")
            Me.demoActiveXBox.Parameters.Add("FlashVars", "&dataURL=../../../../../../Resources/Flash/FC_2_3_DATA.xml")
            Me.demoActiveXBox.Parameters.Add("quality", "high")
            Me.demoActiveXBox.Size = New System.Drawing.Size(391, 306)
            Me.demoActiveXBox.StandBy = ""
            Me.demoActiveXBox.TabIndex = 0
            Me.demoActiveXBox.Type = ""
            '
            'ProvideParametersPage
            '
            Me.Controls.Add(Me.demoActiveXBox)
            Me.Size = New System.Drawing.Size(391, 450)
            Me.Text = "ProvideParametersPage"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents demoActiveXBox As Gizmox.WebGUI.Forms.Hosts.ActiveXBox

	End Class

End Namespace
