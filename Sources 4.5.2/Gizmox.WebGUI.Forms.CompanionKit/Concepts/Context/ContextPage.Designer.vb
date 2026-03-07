Namespace CompanionKit.Concepts.Context

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ContextPage
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
            Me.mobjContextGB = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjButtonLoad1 = New Gizmox.WebGUI.Forms.Button()
            Me.mobjButtonSave1 = New Gizmox.WebGUI.Forms.Button()
            Me.mobjParameterBTxt1 = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjParameterATxt1 = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjParameterB1 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjParameterA1 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjSessionGB = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjButtonLoad3 = New Gizmox.WebGUI.Forms.Button()
            Me.mobjButtonSave3 = New Gizmox.WebGUI.Forms.Button()
            Me.mobjParameterBTxt3 = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjParameterATxt3 = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjParameterB3 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjParameterA3 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjAppGB = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjButtonLoad4 = New Gizmox.WebGUI.Forms.Button()
            Me.mobjButtonSave4 = New Gizmox.WebGUI.Forms.Button()
            Me.mobjParameterBTxt4 = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjParameterATxt4 = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjParameterB4 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjParameterA4 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjCookiesGB = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjParameterBTxt2 = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjParameterATxt2 = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjButtonLoad2 = New Gizmox.WebGUI.Forms.Button()
            Me.mobjButtonSave2 = New Gizmox.WebGUI.Forms.Button()
            Me.mobjParameterB2 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjParameterA2 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjContextTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjCookiesTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjSessionTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjAppTLP = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjContextGB.SuspendLayout()
            Me.mobjSessionGB.SuspendLayout()
            Me.mobjAppGB.SuspendLayout()
            Me.mobjCookiesGB.SuspendLayout()
            Me.mobjTLP.SuspendLayout()
            Me.mobjContextTLP.SuspendLayout()
            Me.mobjCookiesTLP.SuspendLayout()
            Me.mobjSessionTLP.SuspendLayout()
            Me.mobjAppTLP.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjContextGB
            ' 
            Me.mobjContextGB.Controls.Add(Me.mobjContextTLP)
            Me.mobjContextGB.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjContextGB.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjContextGB.Location = New System.Drawing.Point(0, 0)
            Me.mobjContextGB.Name = "mobjContextGB"
            Me.mobjContextGB.Size = New System.Drawing.Size(553, 280)
            Me.mobjContextGB.TabIndex = 0
            Me.mobjContextGB.TabStop = False
            Me.mobjContextGB.Text = "Context Scope Parameters"
            ' 
            ' mobjContextTLP
            ' 
            Me.mobjContextTLP.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjContextTLP.ColumnCount = 2
            Me.mobjContextTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjContextTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjContextTLP.Controls.Add(Me.mobjParameterA1, 0, 0)
            Me.mobjContextTLP.Controls.Add(Me.mobjParameterBTxt1, 1, 1)
            Me.mobjContextTLP.Controls.Add(Me.mobjButtonSave1, 1, 2)
            Me.mobjContextTLP.Controls.Add(Me.mobjParameterATxt1, 1, 0)
            Me.mobjContextTLP.Controls.Add(Me.mobjButtonLoad1, 0, 2)
            Me.mobjContextTLP.Controls.Add(Me.mobjParameterB1, 0, 1)
            Me.mobjContextTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjContextTLP.Location = New System.Drawing.Point(3, 17)
            Me.mobjContextTLP.Name = "mobjContextTLP"
            Me.mobjContextTLP.RowCount = 3
            Me.mobjContextTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjContextTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjContextTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjContextTLP.Size = New System.Drawing.Size(547, 260)
            Me.mobjContextTLP.TabIndex = 6
            ' 
            ' mobjParameterA1
            ' 
            Me.mobjParameterA1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjParameterA1.Location = New System.Drawing.Point(0, 0)
            Me.mobjParameterA1.Name = "mobjParameterA1"
            Me.mobjParameterA1.Size = New System.Drawing.Size(273, 86)
            Me.mobjParameterA1.TabIndex = 0
            Me.mobjParameterA1.Text = "ParameterA:"
            Me.mobjParameterA1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjParameterBTxt1
            ' 
            Me.mobjParameterBTxt1.AcceptsTab = True
            Me.mobjParameterBTxt1.Anchor = (Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right)
            Me.mobjParameterBTxt1.Location = New System.Drawing.Point(200, 114)
            Me.mobjParameterBTxt1.MaximumSize = New System.Drawing.Size(200, 25)
            Me.mobjParameterBTxt1.Name = "mobjParameterBTxt1"
            Me.mobjParameterBTxt1.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both
            Me.mobjParameterBTxt1.Size = New System.Drawing.Size(200, 25)
            Me.mobjParameterBTxt1.TabIndex = 3
            Me.mobjParameterBTxt1.WordWrap = False
            ' 
            ' mobjButtonSave1
            ' 
            Me.mobjButtonSave1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjButtonSave1.Location = New System.Drawing.Point(372, 204)
            Me.mobjButtonSave1.Name = "mobjButtonSave1"
            Me.mobjButtonSave1.Size = New System.Drawing.Size(100, 40)
            Me.mobjButtonSave1.TabIndex = 4
            Me.mobjButtonSave1.Text = "Save"
            ' 
            ' mobjParameterATxt1
            ' 
            Me.mobjParameterATxt1.AcceptsTab = True
            Me.mobjParameterATxt1.Anchor = (Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right)
            Me.mobjParameterATxt1.Location = New System.Drawing.Point(200, 38)
            Me.mobjParameterATxt1.MaximumSize = New System.Drawing.Size(200, 25)
            Me.mobjParameterATxt1.Name = "mobjParameterATxt1"
            Me.mobjParameterATxt1.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both
            Me.mobjParameterATxt1.Size = New System.Drawing.Size(200, 25)
            Me.mobjParameterATxt1.TabIndex = 2
            Me.mobjParameterATxt1.WordWrap = False
            ' 
            ' mobjButtonLoad1
            ' 
            Me.mobjButtonLoad1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjButtonLoad1.Location = New System.Drawing.Point(99, 204)
            Me.mobjButtonLoad1.Name = "mobjButtonLoad1"
            Me.mobjButtonLoad1.Size = New System.Drawing.Size(100, 40)
            Me.mobjButtonLoad1.TabIndex = 5
            Me.mobjButtonLoad1.Text = "Load"
            ' 
            ' mobjParameterB1
            ' 
            Me.mobjParameterB1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjParameterB1.Location = New System.Drawing.Point(0, 86)
            Me.mobjParameterB1.Name = "mobjParameterB1"
            Me.mobjParameterB1.Size = New System.Drawing.Size(273, 86)
            Me.mobjParameterB1.TabIndex = 1
            Me.mobjParameterB1.Text = "ParameterB:"
            Me.mobjParameterB1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjSessionGB
            ' 
            Me.mobjSessionGB.Controls.Add(Me.mobjSessionTLP)
            Me.mobjSessionGB.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSessionGB.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjSessionGB.Location = New System.Drawing.Point(0, 280)
            Me.mobjSessionGB.Name = "mobjSessionGB"
            Me.mobjSessionGB.Size = New System.Drawing.Size(553, 280)
            Me.mobjSessionGB.TabIndex = 1
            Me.mobjSessionGB.TabStop = False
            Me.mobjSessionGB.Text = "Session Scope Parameters"
            ' 
            ' mobjSessionTLP
            ' 
            Me.mobjSessionTLP.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjSessionTLP.ColumnCount = 2
            Me.mobjSessionTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjSessionTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjSessionTLP.Controls.Add(Me.mobjParameterA3, 0, 0)
            Me.mobjSessionTLP.Controls.Add(Me.mobjButtonSave3, 1, 2)
            Me.mobjSessionTLP.Controls.Add(Me.mobjButtonLoad3, 0, 2)
            Me.mobjSessionTLP.Controls.Add(Me.mobjParameterB3, 0, 1)
            Me.mobjSessionTLP.Controls.Add(Me.mobjParameterATxt3, 1, 0)
            Me.mobjSessionTLP.Controls.Add(Me.mobjParameterBTxt3, 1, 1)
            Me.mobjSessionTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjSessionTLP.Location = New System.Drawing.Point(3, 17)
            Me.mobjSessionTLP.Name = "mobjSessionTLP"
            Me.mobjSessionTLP.RowCount = 3
            Me.mobjSessionTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjSessionTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjSessionTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjSessionTLP.Size = New System.Drawing.Size(547, 260)
            Me.mobjSessionTLP.TabIndex = 6
            ' 
            ' mobjParameterA3
            ' 
            Me.mobjParameterA3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjParameterA3.Location = New System.Drawing.Point(0, 0)
            Me.mobjParameterA3.Name = "mobjParameterA3"
            Me.mobjParameterA3.Size = New System.Drawing.Size(273, 86)
            Me.mobjParameterA3.TabIndex = 0
            Me.mobjParameterA3.Text = "ParameterA:"
            Me.mobjParameterA3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjButtonSave3
            ' 
            Me.mobjButtonSave3.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjButtonSave3.Location = New System.Drawing.Point(372, 204)
            Me.mobjButtonSave3.Name = "mobjButtonSave3"
            Me.mobjButtonSave3.Size = New System.Drawing.Size(100, 40)
            Me.mobjButtonSave3.TabIndex = 4
            Me.mobjButtonSave3.Text = "Save"
            ' 
            ' mobjButtonLoad3
            ' 
            Me.mobjButtonLoad3.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjButtonLoad3.Location = New System.Drawing.Point(99, 204)
            Me.mobjButtonLoad3.Name = "mobjButtonLoad3"
            Me.mobjButtonLoad3.Size = New System.Drawing.Size(100, 40)
            Me.mobjButtonLoad3.TabIndex = 5
            Me.mobjButtonLoad3.Text = "Load"
            ' 
            ' mobjParameterB3
            ' 
            Me.mobjParameterB3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjParameterB3.Location = New System.Drawing.Point(0, 86)
            Me.mobjParameterB3.Name = "mobjParameterB3"
            Me.mobjParameterB3.Size = New System.Drawing.Size(273, 86)
            Me.mobjParameterB3.TabIndex = 1
            Me.mobjParameterB3.Text = "ParameterB:"
            Me.mobjParameterB3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjParameterATxt3
            ' 
            Me.mobjParameterATxt3.AcceptsTab = True
            Me.mobjParameterATxt3.Anchor = (Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right)
            Me.mobjParameterATxt3.Location = New System.Drawing.Point(200, 38)
            Me.mobjParameterATxt3.MaximumSize = New System.Drawing.Size(200, 25)
            Me.mobjParameterATxt3.Name = "mobjParameterATxt3"
            Me.mobjParameterATxt3.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both
            Me.mobjParameterATxt3.Size = New System.Drawing.Size(200, 25)
            Me.mobjParameterATxt3.TabIndex = 2
            Me.mobjParameterATxt3.WordWrap = False
            ' 
            ' mobjParameterBTxt3
            ' 
            Me.mobjParameterBTxt3.AcceptsTab = True
            Me.mobjParameterBTxt3.Anchor = (Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right)
            Me.mobjParameterBTxt3.Location = New System.Drawing.Point(200, 114)
            Me.mobjParameterBTxt3.MaximumSize = New System.Drawing.Size(200, 25)
            Me.mobjParameterBTxt3.Name = "mobjParameterBTxt3"
            Me.mobjParameterBTxt3.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both
            Me.mobjParameterBTxt3.Size = New System.Drawing.Size(200, 25)
            Me.mobjParameterBTxt3.TabIndex = 3
            Me.mobjParameterBTxt3.WordWrap = False
            ' 
            ' mobjAppGB
            ' 
            Me.mobjAppGB.Controls.Add(Me.mobjAppTLP)
            Me.mobjAppGB.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAppGB.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjAppGB.Location = New System.Drawing.Point(553, 280)
            Me.mobjAppGB.Name = "mobjAppGB"
            Me.mobjAppGB.Size = New System.Drawing.Size(554, 280)
            Me.mobjAppGB.TabIndex = 2
            Me.mobjAppGB.TabStop = False
            Me.mobjAppGB.Text = "Application Scope Parameters"
            ' 
            ' mobjAppTLP
            ' 
            Me.mobjAppTLP.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjAppTLP.ColumnCount = 2
            Me.mobjAppTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjAppTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjAppTLP.Controls.Add(Me.mobjParameterA4, 0, 0)
            Me.mobjAppTLP.Controls.Add(Me.mobjParameterBTxt4, 1, 1)
            Me.mobjAppTLP.Controls.Add(Me.mobjButtonSave4, 1, 2)
            Me.mobjAppTLP.Controls.Add(Me.mobjParameterATxt4, 1, 0)
            Me.mobjAppTLP.Controls.Add(Me.mobjButtonLoad4, 0, 2)
            Me.mobjAppTLP.Controls.Add(Me.mobjParameterB4, 0, 1)
            Me.mobjAppTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAppTLP.Location = New System.Drawing.Point(3, 17)
            Me.mobjAppTLP.Name = "mobjAppTLP"
            Me.mobjAppTLP.RowCount = 3
            Me.mobjAppTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjAppTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjAppTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjAppTLP.Size = New System.Drawing.Size(548, 260)
            Me.mobjAppTLP.TabIndex = 6
            ' 
            ' mobjParameterA4
            ' 
            Me.mobjParameterA4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjParameterA4.Location = New System.Drawing.Point(0, 0)
            Me.mobjParameterA4.Name = "mobjParameterA4"
            Me.mobjParameterA4.Size = New System.Drawing.Size(274, 86)
            Me.mobjParameterA4.TabIndex = 0
            Me.mobjParameterA4.Text = "ParameterA:"
            Me.mobjParameterA4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjParameterBTxt4
            ' 
            Me.mobjParameterBTxt4.AcceptsTab = True
            Me.mobjParameterBTxt4.Anchor = (Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right)
            Me.mobjParameterBTxt4.Location = New System.Drawing.Point(200, 114)
            Me.mobjParameterBTxt4.MaximumSize = New System.Drawing.Size(200, 25)
            Me.mobjParameterBTxt4.Name = "mobjParameterBTxt4"
            Me.mobjParameterBTxt4.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both
            Me.mobjParameterBTxt4.Size = New System.Drawing.Size(200, 25)
            Me.mobjParameterBTxt4.TabIndex = 3
            Me.mobjParameterBTxt4.WordWrap = False
            ' 
            ' mobjButtonSave4
            ' 
            Me.mobjButtonSave4.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjButtonSave4.Location = New System.Drawing.Point(373, 204)
            Me.mobjButtonSave4.Name = "mobjButtonSave4"
            Me.mobjButtonSave4.Size = New System.Drawing.Size(100, 40)
            Me.mobjButtonSave4.TabIndex = 4
            Me.mobjButtonSave4.Text = "Save"
            ' 
            ' mobjParameterATxt4
            ' 
            Me.mobjParameterATxt4.AcceptsTab = True
            Me.mobjParameterATxt4.Anchor = (Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right)
            Me.mobjParameterATxt4.Location = New System.Drawing.Point(200, 38)
            Me.mobjParameterATxt4.MaximumSize = New System.Drawing.Size(200, 25)
            Me.mobjParameterATxt4.Name = "mobjParameterATxt4"
            Me.mobjParameterATxt4.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both
            Me.mobjParameterATxt4.Size = New System.Drawing.Size(200, 25)
            Me.mobjParameterATxt4.TabIndex = 2
            Me.mobjParameterATxt4.WordWrap = False
            ' 
            ' mobjButtonLoad4
            ' 
            Me.mobjButtonLoad4.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjButtonLoad4.Location = New System.Drawing.Point(99, 204)
            Me.mobjButtonLoad4.Name = "mobjButtonLoad4"
            Me.mobjButtonLoad4.Size = New System.Drawing.Size(100, 40)
            Me.mobjButtonLoad4.TabIndex = 5
            Me.mobjButtonLoad4.Text = "Load"
            ' 
            ' mobjParameterB4
            ' 
            Me.mobjParameterB4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjParameterB4.Location = New System.Drawing.Point(0, 86)
            Me.mobjParameterB4.Name = "mobjParameterB4"
            Me.mobjParameterB4.Size = New System.Drawing.Size(274, 86)
            Me.mobjParameterB4.TabIndex = 1
            Me.mobjParameterB4.Text = "ParameterB:"
            Me.mobjParameterB4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjCookiesGB
            ' 
            Me.mobjCookiesGB.Controls.Add(Me.mobjCookiesTLP)
            Me.mobjCookiesGB.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCookiesGB.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjCookiesGB.Location = New System.Drawing.Point(553, 0)
            Me.mobjCookiesGB.Name = "mobjCookiesGB"
            Me.mobjCookiesGB.Size = New System.Drawing.Size(554, 280)
            Me.mobjCookiesGB.TabIndex = 3
            Me.mobjCookiesGB.TabStop = False
            Me.mobjCookiesGB.Text = "Cookies Scope Parameters"
            ' 
            ' mobjCookiesTLP
            ' 
            Me.mobjCookiesTLP.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjCookiesTLP.ColumnCount = 2
            Me.mobjCookiesTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjCookiesTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjCookiesTLP.Controls.Add(Me.mobjParameterA2, 0, 0)
            Me.mobjCookiesTLP.Controls.Add(Me.mobjButtonSave2, 1, 2)
            Me.mobjCookiesTLP.Controls.Add(Me.mobjButtonLoad2, 0, 2)
            Me.mobjCookiesTLP.Controls.Add(Me.mobjParameterBTxt2, 1, 1)
            Me.mobjCookiesTLP.Controls.Add(Me.mobjParameterB2, 0, 1)
            Me.mobjCookiesTLP.Controls.Add(Me.mobjParameterATxt2, 1, 0)
            Me.mobjCookiesTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCookiesTLP.Location = New System.Drawing.Point(3, 17)
            Me.mobjCookiesTLP.Name = "mobjCookiesTLP"
            Me.mobjCookiesTLP.RowCount = 3
            Me.mobjCookiesTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjCookiesTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjCookiesTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 33.33333F))
            Me.mobjCookiesTLP.Size = New System.Drawing.Size(548, 260)
            Me.mobjCookiesTLP.TabIndex = 6
            ' 
            ' mobjParameterA2
            ' 
            Me.mobjParameterA2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjParameterA2.Location = New System.Drawing.Point(0, 0)
            Me.mobjParameterA2.Name = "mobjParameterA2"
            Me.mobjParameterA2.Size = New System.Drawing.Size(274, 86)
            Me.mobjParameterA2.TabIndex = 0
            Me.mobjParameterA2.Text = "ParameterA:"
            Me.mobjParameterA2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjButtonSave2
            ' 
            Me.mobjButtonSave2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjButtonSave2.Location = New System.Drawing.Point(373, 204)
            Me.mobjButtonSave2.Name = "mobjButtonSave2"
            Me.mobjButtonSave2.Size = New System.Drawing.Size(100, 40)
            Me.mobjButtonSave2.TabIndex = 2
            Me.mobjButtonSave2.Text = "Save"
            ' 
            ' mobjButtonLoad2
            ' 
            Me.mobjButtonLoad2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjButtonLoad2.Location = New System.Drawing.Point(99, 204)
            Me.mobjButtonLoad2.Name = "mobjButtonLoad2"
            Me.mobjButtonLoad2.Size = New System.Drawing.Size(100, 40)
            Me.mobjButtonLoad2.TabIndex = 3
            Me.mobjButtonLoad2.Text = "Load"
            ' 
            ' mobjParameterBTxt2
            ' 
            Me.mobjParameterBTxt2.AcceptsTab = True
            Me.mobjParameterBTxt2.Anchor = (Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right)
            Me.mobjParameterBTxt2.Location = New System.Drawing.Point(200, 114)
            Me.mobjParameterBTxt2.MaximumSize = New System.Drawing.Size(200, 25)
            Me.mobjParameterBTxt2.Name = "mobjParameterBTxt2"
            Me.mobjParameterBTxt2.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both
            Me.mobjParameterBTxt2.Size = New System.Drawing.Size(200, 25)
            Me.mobjParameterBTxt2.TabIndex = 5
            Me.mobjParameterBTxt2.WordWrap = False
            ' 
            ' mobjParameterB2
            ' 
            Me.mobjParameterB2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjParameterB2.Location = New System.Drawing.Point(0, 86)
            Me.mobjParameterB2.Name = "mobjParameterB2"
            Me.mobjParameterB2.Size = New System.Drawing.Size(274, 86)
            Me.mobjParameterB2.TabIndex = 1
            Me.mobjParameterB2.Text = "ParameterB:"
            Me.mobjParameterB2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjParameterATxt2
            ' 
            Me.mobjParameterATxt2.AcceptsTab = True
            Me.mobjParameterATxt2.Anchor = (Gizmox.WebGUI.Forms.AnchorStyles.Left Or Gizmox.WebGUI.Forms.AnchorStyles.Right)
            Me.mobjParameterATxt2.Location = New System.Drawing.Point(200, 38)
            Me.mobjParameterATxt2.MaximumSize = New System.Drawing.Size(200, 25)
            Me.mobjParameterATxt2.Name = "mobjParameterATxt2"
            Me.mobjParameterATxt2.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both
            Me.mobjParameterATxt2.Size = New System.Drawing.Size(200, 25)
            Me.mobjParameterATxt2.TabIndex = 4
            Me.mobjParameterATxt2.WordWrap = False
            ' 
            ' mobjTLP
            ' 
            Me.mobjTLP.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjTLP.ColumnCount = 2
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjTLP.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjTLP.Controls.Add(Me.mobjContextGB, 0, 0)
            Me.mobjTLP.Controls.Add(Me.mobjAppGB, 1, 1)
            Me.mobjTLP.Controls.Add(Me.mobjCookiesGB, 1, 0)
            Me.mobjTLP.Controls.Add(Me.mobjSessionGB, 0, 1)
            Me.mobjTLP.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTLP.Location = New System.Drawing.Point(0, 0)
            Me.mobjTLP.Name = "mobjTLP"
            Me.mobjTLP.RowCount = 2
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjTLP.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjTLP.Size = New System.Drawing.Size(1107, 560)
            Me.mobjTLP.TabIndex = 4
            ' 
            ' ContextPage
            ' 
            Me.AutoScroll = True
            Me.Controls.Add(Me.mobjTLP)
            Me.Size = New System.Drawing.Size(800, 500)
            Me.mobjContextGB.ResumeLayout(False)
            Me.mobjContextTLP.ResumeLayout(False)
            Me.mobjSessionGB.ResumeLayout(False)
            Me.mobjSessionTLP.ResumeLayout(False)
            Me.mobjAppGB.ResumeLayout(False)
            Me.mobjAppTLP.ResumeLayout(False)
            Me.mobjCookiesGB.ResumeLayout(False)
            Me.mobjCookiesTLP.ResumeLayout(False)
            Me.mobjTLP.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub
        Friend WithEvents mobjContextGB As Gizmox.WebGUI.Forms.GroupBox
        Friend WithEvents mobjParameterA1 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjParameterB1 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjParameterATxt1 As Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents mobjParameterBTxt1 As Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents mobjButtonSave1 As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjButtonLoad1 As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjSessionGB As Gizmox.WebGUI.Forms.GroupBox
        Friend WithEvents mobjAppGB As Gizmox.WebGUI.Forms.GroupBox
        Friend WithEvents mobjParameterA3 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjParameterB3 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjParameterA4 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjParameterB4 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjParameterATxt3 As Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents mobjParameterBTxt3 As Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents mobjParameterATxt4 As Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents mobjParameterBTxt4 As Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents mobjButtonSave3 As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjButtonLoad3 As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjButtonSave4 As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjButtonLoad4 As Gizmox.WebGUI.Forms.Button

        Private Shared mobjLock As String = "lock"
        Friend WithEvents mobjCookiesGB As Gizmox.WebGUI.Forms.GroupBox
        Friend WithEvents mobjParameterA2 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjParameterB2 As Gizmox.WebGUI.Forms.Label
        Friend WithEvents mobjButtonSave2 As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjButtonLoad2 As Gizmox.WebGUI.Forms.Button
        Friend WithEvents mobjParameterATxt2 As Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents mobjParameterBTxt2 As Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents mobjTLP As TableLayoutPanel
        Friend WithEvents mobjContextTLP As TableLayoutPanel
        Friend WithEvents mobjCookiesTLP As TableLayoutPanel
        Friend WithEvents mobjSessionTLP As TableLayoutPanel
        Friend WithEvents mobjAppTLP As TableLayoutPanel

    End Class
End Namespace
