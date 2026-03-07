Namespace CompanionKit.Controls.XamlBox.Programming

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
            Me.demoXamlBox = New Gizmox.WebGUI.Forms.Hosts.XamlBox
            Me.SuspendLayout()
            '
            'demoXamlBox
            '
            Me.demoXamlBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.demoXamlBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.demoXamlBox.Location = New System.Drawing.Point(0, 0)
            Me.demoXamlBox.Name = "demoXamlBox"
            Me.demoXamlBox.Parameters.Add("source", "~/Resources/Xaml/Sample.xaml")
            Me.demoXamlBox.Parameters.Add("windowless", False)
            Me.demoXamlBox.Size = New System.Drawing.Size(391, 306)
            Me.demoXamlBox.TabIndex = 0
            Me.demoXamlBox.Url = "~/Resources/Xaml/Sample.xaml"
            Me.demoXamlBox.Windowless = False
            '
            'ProvideParametersPage
            '
            Me.Controls.Add(Me.demoXamlBox)
            Me.Size = New System.Drawing.Size(391, 453)
            Me.Text = "ProvideParametersPage"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents demoXamlBox As Gizmox.WebGUI.Forms.Hosts.XamlBox

	End Class

End Namespace