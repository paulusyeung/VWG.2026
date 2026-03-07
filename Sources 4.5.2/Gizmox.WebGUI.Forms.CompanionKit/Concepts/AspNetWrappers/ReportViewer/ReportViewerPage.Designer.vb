Namespace CompanionKit.Concepts.AspNetWrappers.ReportViewer

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ReportViewerPage
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
            Me.mobjReportViewer = New Gizmox.WebGUI.Reporting.ReportViewer()
            Me.SuspendLayout()
            ' 
            ' mobjReportViewer
            ' 
            Me.mobjReportViewer.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile
            Me.mobjReportViewer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjReportViewer.Name = "mobjReportViewer"

            Me.mobjReportViewer.Size = New System.Drawing.Size(602, 602)
            Me.mobjReportViewer.TabIndex = 0
            ' 
            ' ReportViewerPage
            ' 
            Me.Controls.Add(Me.mobjReportViewer)
            Me.Size = New System.Drawing.Size(391, 600)
            Me.Text = "ReportViewerPage"
        End Sub
        Friend WithEvents mobjReportViewer As Gizmox.WebGUI.Reporting.ReportViewer
    End Class

End Namespace