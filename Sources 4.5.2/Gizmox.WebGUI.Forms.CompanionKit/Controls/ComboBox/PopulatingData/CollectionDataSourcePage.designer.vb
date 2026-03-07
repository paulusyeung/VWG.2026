Imports Gizmox.WebGUI.Forms

Namespace CompanionKit.Controls.ComboBox.PopulatingData

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class CollectionDataSourcePage
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
            Me.mobjComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjBindingSource = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjCollectionLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjValueLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjNameLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjValueTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjNameTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjValueMemberLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDataLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjValueMemberTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjDataTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjErrorProvider = New Gizmox.WebGUI.Forms.ErrorProvider(Me.components)
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjPanel = New Gizmox.WebGUI.Forms.Panel()
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjComboBox
            ' 
            Me.mobjComboBox.AllowDrag = False
            Me.mobjComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjComboBox.DataSource = Me.mobjBindingSource
            Me.mobjComboBox.DisplayMember = "FullName"
            Me.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjComboBox.Location = New System.Drawing.Point(0, 10)
            Me.mobjComboBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjComboBox.Name = "mobjComboBox"
            Me.mobjComboBox.Size = New System.Drawing.Size(200, 21)
            Me.mobjComboBox.TabIndex = 0
            Me.mobjComboBox.ValueMember = "ID"
            ' 
            ' mobjBindingSource
            ' 
            Me.mobjBindingSource.DataSource = GetType(System.Collections.Generic.List(Of Utils.Customer))
            ' 
            ' mobjCollectionLabel
            ' 
            Me.mobjCollectionLabel.AutoSize = True
            Me.mobjCollectionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjCollectionLabel.Location = New System.Drawing.Point(10, 0)
            Me.mobjCollectionLabel.Name = "mobjCollectionLabel"
            Me.mobjCollectionLabel.Size = New System.Drawing.Size(285, 50)
            Me.mobjCollectionLabel.TabIndex = 1
            Me.mobjCollectionLabel.Text = "DataSource: Collection"
            Me.mobjCollectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjValueLabel
            ' 
            Me.mobjValueLabel.AutoSize = True
            Me.mobjValueLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjValueLabel.Location = New System.Drawing.Point(10, 70)
            Me.mobjValueLabel.Name = "mobjValueLabel"
            Me.mobjValueLabel.Size = New System.Drawing.Size(285, 30)
            Me.mobjValueLabel.TabIndex = 2
            Me.mobjValueLabel.Text = "Selected value"
            Me.mobjValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjNameLabel
            ' 
            Me.mobjNameLabel.AutoSize = True
            Me.mobjNameLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjNameLabel.Location = New System.Drawing.Point(10, 120)
            Me.mobjNameLabel.Name = "mobjNameLabel"
            Me.mobjNameLabel.Size = New System.Drawing.Size(285, 30)
            Me.mobjNameLabel.TabIndex = 3
            Me.mobjNameLabel.Text = "Selected Name"
            Me.mobjNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjValueTextBox
            ' 
            Me.mobjValueTextBox.AllowDrag = False
            Me.mobjValueTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjValueTextBox.Location = New System.Drawing.Point(298, 73)
            Me.mobjValueTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjValueTextBox.Name = "mobjValueTextBox"
            Me.mobjValueTextBox.Size = New System.Drawing.Size(200, 24)
            Me.mobjValueTextBox.TabIndex = 4
            ' 
            ' mobjNameTextBox
            ' 
            Me.mobjNameTextBox.AllowDrag = False
            Me.mobjNameTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjNameTextBox.Location = New System.Drawing.Point(298, 123)
            Me.mobjNameTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjNameTextBox.Name = "mobjNameTextBox"
            Me.mobjNameTextBox.Size = New System.Drawing.Size(200, 24)
            Me.mobjNameTextBox.TabIndex = 5
            ' 
            ' mobjValueMemberLabel
            ' 
            Me.mobjValueMemberLabel.AutoSize = True
            Me.mobjValueMemberLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjValueMemberLabel.Location = New System.Drawing.Point(10, 170)
            Me.mobjValueMemberLabel.Name = "mobjValueMemberLabel"
            Me.mobjValueMemberLabel.Size = New System.Drawing.Size(285, 30)
            Me.mobjValueMemberLabel.TabIndex = 6
            Me.mobjValueMemberLabel.Text = "ValueMember"
            Me.mobjValueMemberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjDataLabel
            ' 
            Me.mobjDataLabel.AutoSize = True
            Me.mobjDataLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDataLabel.Location = New System.Drawing.Point(10, 220)
            Me.mobjDataLabel.Name = "mobjDataLabel"
            Me.mobjDataLabel.Size = New System.Drawing.Size(285, 30)
            Me.mobjDataLabel.TabIndex = 7
            Me.mobjDataLabel.Text = "Data"
            Me.mobjDataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjValueMemberTextBox
            ' 
            Me.mobjValueMemberTextBox.AllowDrag = False
            Me.mobjValueMemberTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjValueMemberTextBox.Location = New System.Drawing.Point(298, 173)
            Me.mobjValueMemberTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjValueMemberTextBox.Name = "mobjValueMemberTextBox"
            Me.mobjValueMemberTextBox.Size = New System.Drawing.Size(200, 24)
            Me.mobjValueMemberTextBox.TabIndex = 8
            Me.mobjValueMemberTextBox.Text = "ID"
            ' 
            ' mobjDataTextBox
            ' 
            Me.mobjDataTextBox.AllowDrag = False
            Me.mobjDataTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDataTextBox.Location = New System.Drawing.Point(298, 223)
            Me.mobjDataTextBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjDataTextBox.Name = "mobjDataTextBox"
            Me.mobjDataTextBox.Size = New System.Drawing.Size(200, 24)
            Me.mobjDataTextBox.TabIndex = 9
            Me.mobjDataTextBox.Text = "John John"
            ' 
            ' mobjErrorProvider
            ' 
            Me.mobjErrorProvider.BlinkRate = 3
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjLayoutPanel.ColumnCount = 4
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjCollectionLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDataLabel, 1, 9)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDataTextBox, 2, 9)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjValueMemberTextBox, 2, 7)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjValueMemberLabel, 1, 7)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjValueTextBox, 2, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjValueLabel, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjNameTextBox, 2, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjNameLabel, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjPanel, 2, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 11
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 20.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(590, 250)
            Me.mobjLayoutPanel.TabIndex = 10
            ' 
            ' mobjPanel
            ' 
            Me.mobjPanel.Controls.Add(Me.mobjComboBox)
            Me.mobjPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjPanel.DockPadding.Bottom = 10
            Me.mobjPanel.DockPadding.Top = 10
            Me.mobjPanel.Location = New System.Drawing.Point(295, 0)
            Me.mobjPanel.Name = "mobjPanel"
            Me.mobjPanel.Padding = New Gizmox.WebGUI.Forms.Padding(0, 10, 0, 10)
            Me.mobjPanel.Size = New System.Drawing.Size(285, 50)
            Me.mobjPanel.TabIndex = 0
            ' 
            ' CollectionDataSourcePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(590, 250)
            Me.Text = "CollectionDataSourcePage"
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjCollectionLabel As Gizmox.WebGUI.Forms.Label
        Private mobjBindingSource As Gizmox.WebGUI.Forms.BindingSource
        Private mobjValueLabel As Gizmox.WebGUI.Forms.Label
        Private mobjNameLabel As Gizmox.WebGUI.Forms.Label
        Private mobjValueTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjNameTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjValueMemberLabel As Gizmox.WebGUI.Forms.Label
        Private mobjDataLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjValueMemberTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjDataTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjErrorProvider As Gizmox.WebGUI.Forms.ErrorProvider
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjPanel As Gizmox.WebGUI.Forms.Panel

	End Class

End Namespace
