Namespace CompanionKit.Controls.ZedGraph.Functionality

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class PieChartPage
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(PieChartPage))
            Me.mobjZedGraph = New Gizmox.WebGUI.Forms.Professional.ZedGraphControl()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjTLP.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjZedGraph
            ' 
            Me.mobjZedGraph.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjZedGraph.IsZoomOnMouseCenter = True
            Me.mobjZedGraph.Location = New System.Drawing.Point(0, 60)
            Me.mobjZedGraph.Name = "ZedGraphControl"
            Me.mobjZedGraph.Size = New System.Drawing.Size(320, 340)
            Me.mobjZedGraph.TabIndex = 0
            Me.mobjZedGraph.ToolTipSuspension = 500
            ' 
            ' mobjInfoLabel
            ' 
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(320, 60)
            Me.mobjInfoLabel.TabIndex = 1
            Me.mobjInfoLabel.Text = "ZedGraph with a pie chart:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjTLP
            ' 
            Me.mobjTLP.ColumnCount = 1
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjTLP.Controls.Add(Me.mobjInfoLabel, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjZedGraph, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 2
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 15.0F))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 85.0F))
            Me.mobjTLP.Size = New System.Drawing.Size(320, 400)
            Me.mobjTLP.TabIndex = 2
            ' 
            ' PieChartPage
            ' 
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(320, 400)
            Me.Text = "GraphDemoPage"
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)
		End Sub
        Private mobjInfoLabel As Gizmox.WebGUI.Forms.Label
        Private mobjZedGraph As Gizmox.WebGUI.Forms.Professional.ZedGraphControl
        Private mobjTLP As Gizmox.WebGUI.Forms.TableLayoutPanel
	End Class

End Namespace