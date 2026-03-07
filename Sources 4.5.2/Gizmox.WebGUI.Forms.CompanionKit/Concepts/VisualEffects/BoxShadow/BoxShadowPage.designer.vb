Namespace CompanionKit.Concepts.VisualEffects.BoxShadow

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BoxShadowPage
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
            Me.mobjColorPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjMonthCalendar = New Gizmox.WebGUI.Forms.MonthCalendar()
            Me.mobjShadowInsetCheckBox = New Gizmox.WebGUI.Forms.CheckBox()
            Me.mobjToggleButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjColorDialog = New Gizmox.WebGUI.Forms.ColorDialog()
            Me.mobjTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjThirdTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjSecondTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjChooseColorButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjFirstTopPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjBottomPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjPaddingPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjTopPanel.SuspendLayout()
            Me.mobjThirdTopPanel.SuspendLayout()
            Me.mobjSecondTopPanel.SuspendLayout()
            Me.mobjFirstTopPanel.SuspendLayout()
            Me.mobjBottomPanel.SuspendLayout()
            Me.mobjPaddingPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjColorPanel
            ' 
            Me.mobjColorPanel.AccessibleDescription = ""
            Me.mobjColorPanel.AccessibleName = ""
            Me.mobjColorPanel.BackColor = System.Drawing.Color.Black
            Me.mobjColorPanel.BorderColor = New Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray)
            Me.mobjColorPanel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle
            Me.mobjColorPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjColorPanel.Location = New System.Drawing.Point(15, 0)
            Me.mobjColorPanel.Name = "objColorPanel"
            Me.mobjColorPanel.Size = New System.Drawing.Size(64, 41)
            Me.mobjColorPanel.TabIndex = 10
            ' 
            ' mobjMonthCalendar
            ' 
            Me.mobjMonthCalendar.AccessibleDescription = ""
            Me.mobjMonthCalendar.AccessibleName = ""
            Me.mobjMonthCalendar.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
            Me.mobjMonthCalendar.Location = New System.Drawing.Point(35, 26)
            Me.mobjMonthCalendar.Name = "objMonthCalendar"
            Me.mobjMonthCalendar.SelectionEnd = New System.DateTime(2013, 9, 5, 8, 43, 42, _
             659)
            Me.mobjMonthCalendar.SelectionRange = New Gizmox.WebGUI.Forms.SelectionRange(New System.DateTime(2013, 9, 5, 0, 0, 0, _
             0), New System.DateTime(2013, 9, 5, 0, 0, 0, _
             0))
            Me.mobjMonthCalendar.SelectionStart = New System.DateTime(2013, 9, 5, 8, 43, 42, _
             659)
            Me.mobjMonthCalendar.Size = New System.Drawing.Size(227, 162)
            Me.mobjMonthCalendar.TabIndex = 9
            Me.mobjMonthCalendar.Value = New System.DateTime(2013, 9, 5, 8, 43, 42, _
             659)
            ' 
            ' mobjShadowInsetCheckBox
            ' 
            Me.mobjShadowInsetCheckBox.AccessibleDescription = ""
            Me.mobjShadowInsetCheckBox.AccessibleName = ""
            Me.mobjShadowInsetCheckBox.AutoSize = True
            Me.mobjShadowInsetCheckBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjShadowInsetCheckBox.Location = New System.Drawing.Point(30, 0)
            Me.mobjShadowInsetCheckBox.Name = "objShadowInsetCheckBox"
            Me.mobjShadowInsetCheckBox.Size = New System.Drawing.Size(79, 39)
            Me.mobjShadowInsetCheckBox.TabIndex = 6
            Me.mobjShadowInsetCheckBox.Text = "Apply inset"
            ' 
            ' mobjToggleButton
            ' 
            Me.mobjToggleButton.AccessibleDescription = ""
            Me.mobjToggleButton.AccessibleName = ""
            Me.mobjToggleButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjToggleButton.Location = New System.Drawing.Point(30, 5)
            Me.mobjToggleButton.Name = "objApplyButton"
            Me.mobjToggleButton.Size = New System.Drawing.Size(241, 46)
            Me.mobjToggleButton.TabIndex = 7
            Me.mobjToggleButton.Text = "Show BoxShadow"
            ' 
            ' mobjTopPanel
            ' 
            Me.mobjTopPanel.AccessibleDescription = ""
            Me.mobjTopPanel.AccessibleName = ""
            Me.mobjTopPanel.Controls.Add(Me.mobjThirdTopPanel)
            Me.mobjTopPanel.Controls.Add(Me.mobjSecondTopPanel)
            Me.mobjTopPanel.Controls.Add(Me.mobjFirstTopPanel)
            Me.mobjTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjTopPanel.Location = New System.Drawing.Point(0, 10)
            Me.mobjTopPanel.Name = "objTopPanel"
            Me.mobjTopPanel.Size = New System.Drawing.Size(301, 150)
            Me.mobjTopPanel.TabIndex = 11
            ' 
            ' mobjThirdTopPanel
            ' 
            Me.mobjThirdTopPanel.AccessibleDescription = ""
            Me.mobjThirdTopPanel.AccessibleName = ""
            Me.mobjThirdTopPanel.Controls.Add(Me.mobjToggleButton)
            Me.mobjThirdTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjThirdTopPanel.DockPadding.Bottom = 5
            Me.mobjThirdTopPanel.DockPadding.Left = 30
            Me.mobjThirdTopPanel.DockPadding.Right = 30
            Me.mobjThirdTopPanel.DockPadding.Top = 5
            Me.mobjThirdTopPanel.Location = New System.Drawing.Point(0, 94)
            Me.mobjThirdTopPanel.Name = "mobjThirdTopPanel"
            Me.mobjThirdTopPanel.Padding = New Gizmox.WebGUI.Forms.Padding(30, 5, 30, 5)
            Me.mobjThirdTopPanel.Size = New System.Drawing.Size(301, 56)
            Me.mobjThirdTopPanel.TabIndex = 13
            ' 
            ' mobjSecondTopPanel
            ' 
            Me.mobjSecondTopPanel.AccessibleDescription = ""
            Me.mobjSecondTopPanel.AccessibleName = ""
            Me.mobjSecondTopPanel.Controls.Add(Me.mobjPaddingPanel)
            Me.mobjSecondTopPanel.Controls.Add(Me.mobjChooseColorButton)
            Me.mobjSecondTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjSecondTopPanel.DockPadding.Bottom = 7
            Me.mobjSecondTopPanel.DockPadding.Left = 30
            Me.mobjSecondTopPanel.DockPadding.Top = 7
            Me.mobjSecondTopPanel.Location = New System.Drawing.Point(0, 39)
            Me.mobjSecondTopPanel.Name = "panel2"
            Me.mobjSecondTopPanel.Padding = New Gizmox.WebGUI.Forms.Padding(30, 7, 0, 7)
            Me.mobjSecondTopPanel.Size = New System.Drawing.Size(301, 55)
            Me.mobjSecondTopPanel.TabIndex = 12
            ' 
            ' mobjChooseColorButton
            ' 
            Me.mobjChooseColorButton.AccessibleDescription = ""
            Me.mobjChooseColorButton.AccessibleName = ""
            Me.mobjChooseColorButton.AutoSize = True
            Me.mobjChooseColorButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjChooseColorButton.Location = New System.Drawing.Point(30, 7)
            Me.mobjChooseColorButton.Name = "button1"
            Me.mobjChooseColorButton.Size = New System.Drawing.Size(152, 41)
            Me.mobjChooseColorButton.TabIndex = 11
            Me.mobjChooseColorButton.Text = "Choose ShadowColor"
            ' 
            ' mobjFirstTopPanel
            ' 
            Me.mobjFirstTopPanel.AccessibleDescription = ""
            Me.mobjFirstTopPanel.AccessibleName = ""
            Me.mobjFirstTopPanel.Controls.Add(Me.mobjShadowInsetCheckBox)
            Me.mobjFirstTopPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjFirstTopPanel.DockPadding.Left = 30
            Me.mobjFirstTopPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjFirstTopPanel.Name = "panel1"
            Me.mobjFirstTopPanel.Padding = New Gizmox.WebGUI.Forms.Padding(30, 0, 0, 0)
            Me.mobjFirstTopPanel.Size = New System.Drawing.Size(301, 39)
            Me.mobjFirstTopPanel.TabIndex = 11
            ' 
            ' mobjBottomPanel
            ' 
            Me.mobjBottomPanel.AccessibleDescription = ""
            Me.mobjBottomPanel.AccessibleName = ""
            Me.mobjBottomPanel.Controls.Add(Me.mobjMonthCalendar)
            Me.mobjBottomPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjBottomPanel.Location = New System.Drawing.Point(0, 160)
            Me.mobjBottomPanel.Name = "objBottomPanel"
            Me.mobjBottomPanel.Size = New System.Drawing.Size(301, 222)
            Me.mobjBottomPanel.TabIndex = 12
            ' 
            ' mobjPaddingPanel
            ' 
            Me.mobjPaddingPanel.AccessibleDescription = ""
            Me.mobjPaddingPanel.AccessibleName = ""
            Me.mobjPaddingPanel.Controls.Add(Me.mobjColorPanel)
            Me.mobjPaddingPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left
            Me.mobjPaddingPanel.DockPadding.Left = 15
            Me.mobjPaddingPanel.Location = New System.Drawing.Point(182, 7)
            Me.mobjPaddingPanel.Name = "mobjPaddingPanel"
            Me.mobjPaddingPanel.Padding = New Gizmox.WebGUI.Forms.Padding(15, 0, 0, 0)
            Me.mobjPaddingPanel.Size = New System.Drawing.Size(100, 41)
            Me.mobjPaddingPanel.TabIndex = 12
            ' 
            ' BoxShadowPage
            ' 
            Me.Controls.Add(Me.mobjBottomPanel)
            Me.Controls.Add(Me.mobjTopPanel)
            Me.DockPadding.Top = 10
            Me.Location = New System.Drawing.Point(0, -9)
            Me.Padding = New Gizmox.WebGUI.Forms.Padding(0, 10, 0, 0)
            Me.Size = New System.Drawing.Size(301, 382)
            Me.Text = "BoxShadowPage"
            Me.mobjTopPanel.ResumeLayout(False)
            Me.mobjThirdTopPanel.ResumeLayout(False)
            Me.mobjSecondTopPanel.ResumeLayout(False)
            Me.mobjFirstTopPanel.ResumeLayout(False)
            Me.mobjBottomPanel.ResumeLayout(False)
            Me.mobjPaddingPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjColorPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjMonthCalendar As Gizmox.WebGUI.Forms.MonthCalendar
        Private WithEvents mobjShadowInsetCheckBox As Gizmox.WebGUI.Forms.CheckBox
        Private WithEvents mobjToggleButton As Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjColorDialog As Gizmox.WebGUI.Forms.ColorDialog
        Private mobjTopPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjBottomPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjThirdTopPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjSecondTopPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjFirstTopPanel As Gizmox.WebGUI.Forms.Panel
        Private WithEvents mobjChooseColorButton As Gizmox.WebGUI.Forms.Button
        Private mobjPaddingPanel As Gizmox.WebGUI.Forms.Panel

    End Class

End Namespace