Namespace CompanionKit.Controls.Chart.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class ThemePropertyPage
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
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjThemesComboBox = New Gizmox.WebGUI.Forms.ComboBox()
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
            Me.mobjTLP.SetColumnSpan(Me.mobjChart, 2)
            Me.mobjChart.Location = New System.Drawing.Point(117, 0)
            Me.mobjChart.Name = "mobjChart"
            Me.mobjChart.Size = New System.Drawing.Size(400, 382)
            Me.mobjChart.TabIndex = 0
            Me.mobjChart.Theme = Gizmox.WebGUI.Forms.Charts.ThemeTypes.Theme1
            Me.mobjChart.Title = Nothing
            Me.mobjChart.View3D = False
            '
            'mobjLabel
            '
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel.Location = New System.Drawing.Point(0, 382)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 0, 10, 0)
            Me.mobjLabel.Size = New System.Drawing.Size(200, 68)
            Me.mobjLabel.TabIndex = 1
            Me.mobjLabel.Text = "Theme"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mobjThemesComboBox
            '
            Me.mobjThemesComboBox.Anchor = CType((Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right), Gizmox.WebGUI.Forms.AnchorStyles)
            Me.mobjThemesComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjThemesComboBox.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList
            Me.mobjThemesComboBox.FormattingEnabled = True
            Me.mobjThemesComboBox.Location = New System.Drawing.Point(210, 405)
            Me.mobjThemesComboBox.Margin = New Gizmox.WebGUI.Forms.Padding(10, 0, 10, 0)
            Me.mobjThemesComboBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjThemesComboBox.Name = "mobjThemesComboBox"
            Me.mobjThemesComboBox.Size = New System.Drawing.Size(180, 25)
            Me.mobjThemesComboBox.TabIndex = 2
            '
            'mobjTLP
            '
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0!))
            Me.mobjTLP.Controls.Add(Me.mobjChart, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjThemesComboBox, 1, 1)
            Me.mobjTLP.Controls.Add(Me.mobjLabel, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.MaximumSize = New System.Drawing.Size(1280, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 2
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 85.0!))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0!))
            Me.mobjTLP.Size = New System.Drawing.Size(400, 450)
            Me.mobjTLP.TabIndex = 3
            '
            'ThemePropertyPage
            '
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(400, 450)
            Me.Text = "ThemePropertyPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjChart As Gizmox.WebGUI.Forms.Charts.Chart
        Private WithEvents mobjLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjThemesComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private WithEvents mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace