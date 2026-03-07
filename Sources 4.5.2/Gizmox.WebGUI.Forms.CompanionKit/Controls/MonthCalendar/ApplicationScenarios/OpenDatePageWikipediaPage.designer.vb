Namespace CompanionKit.Controls.MonthCalendar.ApplicationScenarios

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class OpenDatePageWikipediaPage
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
            Me.mobjWikiPageHtmlBox = New Gizmox.WebGUI.Forms.HtmlBox()
            Me.mobjDemoMonthCalendar = New Gizmox.WebGUI.Forms.MonthCalendar()
            Me.mobjDateLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjHTMLPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjPanel.SuspendLayout()
            Me.mobjHTMLPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjWikiPageHtmlBox
            ' 
            Me.mobjWikiPageHtmlBox.ContentType = "text/html"
            Me.mobjWikiPageHtmlBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjWikiPageHtmlBox.Html = ""
            Me.mobjWikiPageHtmlBox.Location = New System.Drawing.Point(0, 0)
            Me.mobjWikiPageHtmlBox.Name = "mobjWikiPageHtmlBox"
            Me.mobjWikiPageHtmlBox.Size = New System.Drawing.Size(496, 329)
            Me.mobjWikiPageHtmlBox.TabIndex = 0
            Me.mobjWikiPageHtmlBox.Url = "http://en.wikipedia.org/wiki/December_12"
            ' 
            ' mobjDemoMonthCalendar
            ' 
            Me.mobjDemoMonthCalendar.Location = New System.Drawing.Point(62, 70)
            Me.mobjDemoMonthCalendar.Name = "mobjDemoMonthCalendar"
            Me.mobjDemoMonthCalendar.SelectionEnd = New System.DateTime(2010, 5, 7, 16, 45, 46, _
             84)
            Me.mobjDemoMonthCalendar.SelectionRange = New Gizmox.WebGUI.Forms.SelectionRange(New System.DateTime(2010, 5, 7, 0, 0, 0, _
             0), New System.DateTime(2010, 5, 7, 0, 0, 0, _
             0))
            Me.mobjDemoMonthCalendar.SelectionStart = New System.DateTime(2010, 5, 7, 16, 45, 46, _
             84)
            Me.mobjDemoMonthCalendar.Size = New System.Drawing.Size(227, 162)
            Me.mobjDemoMonthCalendar.TabIndex = 1
            Me.mobjDemoMonthCalendar.Value = New System.DateTime(2010, 5, 7, 16, 45, 46, _
             84)
            ' 
            ' mobjDateLabel
            ' 
            Me.mobjDateLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDateLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjDateLabel.Name = "mobjDateLabel"
            Me.mobjDateLabel.Size = New System.Drawing.Size(805, 30)
            Me.mobjDateLabel.TabIndex = 2
            Me.mobjDateLabel.Text = "Select a date from the calendar to see Wikipedia related page"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 5
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 227.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPanel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDemoMonthCalendar, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjHTMLPanel, 3, 3)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 6
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 162.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 80.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 10.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(867, 421)
            Me.mobjLayoutPanel.TabIndex = 3
            ' 
            ' mobjPanel
            ' 
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjPanel, 4)
            Me.mobjPanel.Controls.Add(Me.mobjDateLabel)
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel.Location = New System.Drawing.Point(62, 20)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(805, 30)
            Me.mobjPanel.TabIndex = 0
            ' 
            ' mobjHTMLPanel
            ' 
            Me.mobjHTMLPanel.Controls.Add(Me.mobjWikiPageHtmlBox)
            Me.mobjHTMLPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjHTMLPanel.Location = New System.Drawing.Point(309, 70)
            Me.mobjHTMLPanel.Name = "mobjHTMLPanel"
            Me.mobjLayoutPanel.SetRowSpan(Me.mobjHTMLPanel, 2)
            Me.mobjHTMLPanel.Size = New System.Drawing.Size(496, 329)
            Me.mobjHTMLPanel.TabIndex = 0
            ' 
            ' OpenDatePageWikipediaPage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(867, 421)
            Me.Text = "OpenDatePageWikipediaPage"
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjPanel.ResumeLayout(False)
            Me.mobjHTMLPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjWikiPageHtmlBox As Gizmox.WebGUI.Forms.HtmlBox
        Private WithEvents mobjDemoMonthCalendar As Gizmox.WebGUI.Forms.MonthCalendar
        Private mobjDateLabel As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjHTMLPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace
