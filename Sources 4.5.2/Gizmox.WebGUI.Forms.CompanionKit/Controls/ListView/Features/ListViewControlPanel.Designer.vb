<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListViewControlPanel
    Inherits Gizmox.WebGui.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Visual WebGui Designer
    Private Shadows components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Visual WebGui Designer
    'It can be modified using the Visual WebGui Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tabControl1 = New Gizmox.WebGUI.Forms.TabControl
        Me.tabPage1 = New Gizmox.WebGUI.Forms.TabPage
        Me.tabPage2 = New Gizmox.WebGUI.Forms.TabPage
        Me.checkBoxAttachments = New Gizmox.WebGUI.Forms.CheckBox
        Me.checkBoxRead = New Gizmox.WebGUI.Forms.CheckBox
        Me.checkBoxImportant = New Gizmox.WebGUI.Forms.CheckBox
        Me.label1 = New Gizmox.WebGUI.Forms.Label
        Me.textBoxSize = New Gizmox.WebGUI.Forms.TextBox
        Me.textBoxSubject = New Gizmox.WebGUI.Forms.TextBox
        Me.label2 = New Gizmox.WebGUI.Forms.Label
        Me.textBoxFrom = New Gizmox.WebGUI.Forms.TextBox
        Me.label3 = New Gizmox.WebGUI.Forms.Label
        Me.tabControl1.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabControl1
        '
        Me.tabControl1.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top
        Me.tabControl1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
        Me.tabControl1.Location = New System.Drawing.Point(0, 0)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(541, 122)
        Me.tabControl1.TabIndex = 0
        '
        'tabPage1
        '
        Me.tabPage1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
        Me.tabPage1.Controls.Add(Me.checkBoxImportant)
        Me.tabPage1.Controls.Add(Me.checkBoxRead)
        Me.tabPage1.Controls.Add(Me.checkBoxAttachments)
        Me.tabPage1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
        Me.tabPage1.Location = New System.Drawing.Point(4, 22)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Size = New System.Drawing.Size(533, 96)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "General"
        '
        'tabPage2
        '
        Me.tabPage2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None
        Me.tabPage2.Controls.Add(Me.label3)
        Me.tabPage2.Controls.Add(Me.textBoxFrom)
        Me.tabPage2.Controls.Add(Me.label2)
        Me.tabPage2.Controls.Add(Me.textBoxSubject)
        Me.tabPage2.Controls.Add(Me.textBoxSize)
        Me.tabPage2.Controls.Add(Me.label1)
        Me.tabPage2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
        Me.tabPage2.Location = New System.Drawing.Point(4, 22)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Size = New System.Drawing.Size(533, 96)
        Me.tabPage2.TabIndex = 0
        Me.tabPage2.Text = "Address"
        '
        'checkBoxAttachments
        '
        Me.checkBoxAttachments.AutoSize = True
        Me.checkBoxAttachments.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked
        Me.checkBoxAttachments.Location = New System.Drawing.Point(10, 13)
        Me.checkBoxAttachments.Name = "checkBoxAttachments"
        Me.checkBoxAttachments.Size = New System.Drawing.Size(87, 17)
        Me.checkBoxAttachments.TabIndex = 0
        Me.checkBoxAttachments.Text = "Attachments"
        Me.checkBoxAttachments.UseVisualStyleBackColor = True
        '
        'checkBoxRead
        '
        Me.checkBoxRead.AutoSize = True
        Me.checkBoxRead.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked
        Me.checkBoxRead.Location = New System.Drawing.Point(10, 31)
        Me.checkBoxRead.Name = "checkBoxRead"
        Me.checkBoxRead.Size = New System.Drawing.Size(51, 17)
        Me.checkBoxRead.TabIndex = 1
        Me.checkBoxRead.Text = "Read"
        Me.checkBoxRead.UseVisualStyleBackColor = True
        '
        'checkBoxImportant
        '
        Me.checkBoxImportant.AutoSize = True
        Me.checkBoxImportant.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked
        Me.checkBoxImportant.Location = New System.Drawing.Point(10, 49)
        Me.checkBoxImportant.Name = "checkBoxImportant"
        Me.checkBoxImportant.Size = New System.Drawing.Size(74, 17)
        Me.checkBoxImportant.TabIndex = 2
        Me.checkBoxImportant.Text = "Important"
        Me.checkBoxImportant.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(17, 13)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(38, 13)
        Me.label1.TabIndex = 0
        Me.label1.Text = "From"
        '
        'textBoxSize
        '
        Me.textBoxSize.Location = New System.Drawing.Point(69, 64)
        Me.textBoxSize.Name = "textBoxSize"
        Me.textBoxSize.Size = New System.Drawing.Size(438, 20)
        Me.textBoxSize.TabIndex = 1
        '
        'textBoxSubject
        '
        Me.textBoxSubject.Location = New System.Drawing.Point(69, 37)
        Me.textBoxSubject.Name = "textBoxSubject"
        Me.textBoxSubject.Size = New System.Drawing.Size(156, 20)
        Me.textBoxSubject.TabIndex = 2
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(20, 40)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(38, 13)
        Me.label2.TabIndex = 3
        Me.label2.Text = "Subject"
        '
        'textBoxFrom
        '
        Me.textBoxFrom.Location = New System.Drawing.Point(69, 10)
        Me.textBoxFrom.Name = "textBoxFrom"
        Me.textBoxFrom.Size = New System.Drawing.Size(156, 20)
        Me.textBoxFrom.TabIndex = 4
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(20, 67)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(38, 13)
        Me.label3.TabIndex = 5
        Me.label3.Text = "Size"
        '
        'ListViewControlPanel
        '
        Me.Controls.Add(Me.tabControl1)
        Me.Size = New System.Drawing.Size(541, 122)
        Me.tabControl1.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.tabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabControl1 As Gizmox.WebGUI.Forms.TabControl
    Friend WithEvents tabPage1 As Gizmox.WebGUI.Forms.TabPage
    Friend WithEvents checkBoxImportant As Gizmox.WebGUI.Forms.CheckBox
    Friend WithEvents checkBoxRead As Gizmox.WebGUI.Forms.CheckBox
    Friend WithEvents checkBoxAttachments As Gizmox.WebGUI.Forms.CheckBox
    Friend WithEvents tabPage2 As Gizmox.WebGUI.Forms.TabPage
    Friend WithEvents label3 As Gizmox.WebGUI.Forms.Label
    Friend WithEvents textBoxFrom As Gizmox.WebGUI.Forms.TextBox
    Friend WithEvents label2 As Gizmox.WebGUI.Forms.Label
    Friend WithEvents textBoxSubject As Gizmox.WebGUI.Forms.TextBox
    Friend WithEvents textBoxSize As Gizmox.WebGUI.Forms.TextBox
    Friend WithEvents label1 As Gizmox.WebGUI.Forms.Label

End Class
