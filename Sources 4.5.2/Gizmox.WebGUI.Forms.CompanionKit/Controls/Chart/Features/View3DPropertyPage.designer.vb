Namespace CompanionKit.Controls.Chart.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class View3DPropertyPage
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
            Me.mobjChart = New Gizmox.WebGUI.Forms.Charts.Chart()
            Me.mobjView3DCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            '
            'mobjChart
            '
            Me.mobjChart.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjChart.AnimationEnabled = False
            Me.mobjChart.AnimationType = Gizmox.WebGUI.Forms.Charts.AnimationTypes.Type1
            Me.mobjChart.AxisX = Nothing
            Me.mobjChart.AxisY = Nothing
            Me.mobjChart.ColorSet = Nothing
            Me.mobjChart.Location = New System.Drawing.Point(0, 16)
            Me.mobjChart.Name = "mobjChart"
            Me.mobjChart.Size = New System.Drawing.Size(400, 350)
            Me.mobjChart.TabIndex = 0
            Me.mobjChart.Theme = Gizmox.WebGUI.Forms.Charts.ThemeTypes.Theme1
            Me.mobjChart.Title = Nothing
            Me.mobjChart.View3D = False
            '
            'mobjView3DCheckBox
            '
            Me.mobjView3DCheckBox.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjView3DCheckBox.Location = New System.Drawing.Point(160, 391)
            Me.mobjView3DCheckBox.Name = "mobjView3DCheckBox"
            Me.mobjView3DCheckBox.Size = New System.Drawing.Size(80, 50)
            Me.mobjView3DCheckBox.TabIndex = 0
            Me.mobjView3DCheckBox.Text = "View 3D"
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0!))
            Me.mobjTLP.Controls.Add(Me.mobjChart, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjView3DCheckBox, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 2
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 85.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(400, 450)
            Me.mobjTLP.TabIndex = 1
            '
            'View3DPropertyPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(400, 450)
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjChart As Gizmox.WebGUI.Forms.Charts.Chart
        Private WithEvents mobjView3DCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace