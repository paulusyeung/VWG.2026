Namespace CompanionKit.Controls.ActiveXBox.ApplicationScenario

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ExampleApplicationPage
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExampleApplicationPage))
            Me.demoActiveXBox = New Gizmox.WebGUI.Forms.Hosts.ActiveXBox
            Me.SuspendLayout()
            '
            'demoActiveXBox
            '
            Me.demoActiveXBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.demoActiveXBox.BackgroundImage = New Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("demoActiveXBox.BackgroundImage"))
            Me.demoActiveXBox.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Stretch
            Me.demoActiveXBox.ClassId = "CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6"
            Me.demoActiveXBox.CodeBase = "http://active.macromedia.com/flash5/cabs/swflash.cab#version=5,0,0,0"
            Me.demoActiveXBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.demoActiveXBox.Location = New System.Drawing.Point(0, 0)
            Me.demoActiveXBox.Name = "demoActiveXBox"
            Me.demoActiveXBox.Size = New System.Drawing.Size(391, 306)
            Me.demoActiveXBox.StandBy = ""
            Me.demoActiveXBox.TabIndex = 0
            Me.demoActiveXBox.Type = ""
            '
            'ExampleApplicationPage
            '
            Me.Controls.Add(Me.demoActiveXBox)
            Me.Size = New System.Drawing.Size(391, 306)
            Me.Text = "ExampleApplicationPage"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents demoActiveXBox As Gizmox.WebGUI.Forms.Hosts.ActiveXBox

	End Class

End Namespace
