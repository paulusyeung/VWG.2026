Namespace CompanionKit.Controls.BindingNavigator.Features

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class CountItemFormatPropertyPage
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
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjBindingNavigator = New Gizmox.WebGUI.Forms.BindingNavigator(Me.components)
            Me.mobjBindingSource = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjSuffixTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjPrefixLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjCenterTextTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjCenterLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjPrefixTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjSuffixLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjPanel.SuspendLayout()
            DirectCast(Me.mobjBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' mobjPanel
            ' 
            Me.mobjPanel.Controls.Add(Me.mobjButton)
            Me.mobjPanel.Controls.Add(Me.mobjBindingNavigator)
            Me.mobjPanel.Controls.Add(Me.mobjSuffixTextBox)
            Me.mobjPanel.Controls.Add(Me.mobjPrefixLabel)
            Me.mobjPanel.Controls.Add(Me.mobjCenterTextTextBox)
            Me.mobjPanel.Controls.Add(Me.mobjCenterLabel)
            Me.mobjPanel.Controls.Add(Me.mobjPrefixTextBox)
            Me.mobjPanel.Controls.Add(Me.mobjSuffixLabel)
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Size = New System.Drawing.Size(500, 286)
            Me.mobjPanel.TabIndex = 0
            ' 
            ' mobjButton
            ' 
            Me.mobjButton.Location = New System.Drawing.Point(11, 220)
            Me.mobjButton.Name = "mobjButton"
            Me.mobjButton.Size = New System.Drawing.Size(150, 50)
            Me.mobjButton.TabIndex = 7
            Me.mobjButton.Text = "Set"
            Me.mobjButton.UseVisualStyleBackColor = True
            ' 
            ' mobjBindingNavigator
            ' 
            Me.mobjBindingNavigator.BindingSource = Me.mobjBindingSource
            Me.mobjBindingNavigator.DragHandle = True
            Me.mobjBindingNavigator.DropDownArrows = True
            Me.mobjBindingNavigator.ImageSize = New System.Drawing.Size(16, 16)
            Me.mobjBindingNavigator.Location = New System.Drawing.Point(0, 0)
            Me.mobjBindingNavigator.MenuHandle = True
            Me.mobjBindingNavigator.Name = "mobjBindingNavigator"
            Me.mobjBindingNavigator.ShowToolTips = True
            Me.mobjBindingNavigator.Size = New System.Drawing.Size(500, 28)
            Me.mobjBindingNavigator.TabIndex = 0
            Me.mobjBindingNavigator.AddStandardItems()
            ' 
            ' mobjSuffixTextBox
            ' 
            Me.mobjSuffixTextBox.AllowDrag = False
            Me.mobjSuffixTextBox.Location = New System.Drawing.Point(11, 172)
            Me.mobjSuffixTextBox.Name = "mobjSuffixTextBox"
            Me.mobjSuffixTextBox.Size = New System.Drawing.Size(150, 30)
            Me.mobjSuffixTextBox.TabIndex = 6
            Me.mobjSuffixTextBox.Text = "Pages"
            ' 
            ' mobjPrefixLabel
            ' 
            Me.mobjPrefixLabel.AutoSize = True
            Me.mobjPrefixLabel.Location = New System.Drawing.Point(11, 36)
            Me.mobjPrefixLabel.Name = "mobjPrefixLabel"
            Me.mobjPrefixLabel.Size = New System.Drawing.Size(35, 13)
            Me.mobjPrefixLabel.TabIndex = 1
            Me.mobjPrefixLabel.Text = "Prefix"
            ' 
            ' mobjCenterTextTextBox
            ' 
            Me.mobjCenterTextTextBox.AllowDrag = False
            Me.mobjCenterTextTextBox.Location = New System.Drawing.Point(11, 114)
            Me.mobjCenterTextTextBox.Name = "mobjCenterTextTextBox"
            Me.mobjCenterTextTextBox.Size = New System.Drawing.Size(150, 30)
            Me.mobjCenterTextTextBox.TabIndex = 5
            Me.mobjCenterTextTextBox.Text = "of"
            ' 
            ' mobjCenterLabel
            ' 
            Me.mobjCenterLabel.AutoSize = True
            Me.mobjCenterLabel.Location = New System.Drawing.Point(11, 94)
            Me.mobjCenterLabel.Name = "mobjCenterLabel"
            Me.mobjCenterLabel.Size = New System.Drawing.Size(63, 13)
            Me.mobjCenterLabel.TabIndex = 2
            Me.mobjCenterLabel.Text = "Center text"
            ' 
            ' mobjPrefixTextBox
            ' 
            Me.mobjPrefixTextBox.AllowDrag = False
            Me.mobjPrefixTextBox.Location = New System.Drawing.Point(11, 56)
            Me.mobjPrefixTextBox.Name = "mobjPrefixTextBox"
            Me.mobjPrefixTextBox.Size = New System.Drawing.Size(150, 30)
            Me.mobjPrefixTextBox.TabIndex = 4
            Me.mobjPrefixTextBox.Text = "Page"
            ' 
            ' mobjSuffixLabel
            ' 
            Me.mobjSuffixLabel.AutoSize = True
            Me.mobjSuffixLabel.Location = New System.Drawing.Point(11, 152)
            Me.mobjSuffixLabel.Name = "mobjSuffixLabel"
            Me.mobjSuffixLabel.Size = New System.Drawing.Size(35, 13)
            Me.mobjSuffixLabel.TabIndex = 3
            Me.mobjSuffixLabel.Text = "Suffix"
            ' 
            ' CountItemFormatPropertyPage
            ' 
            Me.Controls.Add(Me.mobjPanel)
            Me.Size = New System.Drawing.Size(500, 286)
            Me.Text = "CountItemFormatPropertyPage"
            Me.mobjPanel.ResumeLayout(False)
            DirectCast(Me.mobjBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Private mobjPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjBindingNavigator As Gizmox.WebGUI.Forms.BindingNavigator
        Private mobjPrefixLabel As Gizmox.WebGUI.Forms.Label
        Private mobjCenterLabel As Gizmox.WebGUI.Forms.Label
        Private mobjSuffixLabel As Gizmox.WebGUI.Forms.Label
        Private mobjPrefixTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjCenterTextTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjSuffixTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjButton As Gizmox.WebGUI.Forms.Button
        Private mobjBindingSource As Gizmox.WebGUI.Forms.BindingSource

	End Class

End Namespace