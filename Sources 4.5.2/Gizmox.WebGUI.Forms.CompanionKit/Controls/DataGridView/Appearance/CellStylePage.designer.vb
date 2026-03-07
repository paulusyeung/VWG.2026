Namespace CompanionKit.Controls.DataGridView.Appearance

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class CellStylePage
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
            Dim dataGridViewCellStyle7 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle8 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle9 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle10 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle11 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle12 As New Gizmox.WebGUI.Forms.DataGridViewCellStyle()
            Me.mobjDataGridView = New Gizmox.WebGUI.Forms.DataGridView()
            Me.mobjDataGridViewTextBoxColumn1 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjDataGridViewTextBoxColumn2 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjDataGridViewTextBoxColumn3 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjDataGridViewTextBoxColumn4 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjDataGridViewTextBoxColumn5 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjDataGridViewTextBoxColumn6 = New Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn()
            Me.mobjBindingSource = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjGroupBox = New Gizmox.WebGUI.Forms.GroupBox()
            Me.mobjTopLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjColorsPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjColorsLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjColorComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjWrapModePanel = New Gizmox.WebGUI.Forms.Panel()
            Me.wrapModeLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjWrapModeComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjColorButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjFontPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjFontLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjFontChangeButton = New Gizmox.WebGUI.Forms.Button()
            Me.mobjAlignmentPanel = New Gizmox.WebGUI.Forms.Panel()
            Me.mobjAlignLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjAlignComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjColorDialog = New Gizmox.WebGUI.Forms.ColorDialog()
            Me.mobjFontDialog = New Gizmox.WebGUI.Forms.FontDialog()
            Me.mobjDescriptionLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            DirectCast(Me.mobjDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjGroupBox.SuspendLayout()
            Me.mobjTopLayoutPanel.SuspendLayout()
            Me.mobjColorsPanel.SuspendLayout()
            Me.mobjWrapModePanel.SuspendLayout()
            Me.mobjFontPanel.SuspendLayout()
            Me.mobjAlignmentPanel.SuspendLayout()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjDataGridView
            ' 
            Me.mobjDataGridView.AllowDrag = False
            Me.mobjDataGridView.AutoGenerateColumns = False
            Me.mobjDataGridView.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.mobjDataGridView.Columns.AddRange(New Gizmox.WebGUI.Forms.DataGridViewColumn() {Me.mobjDataGridViewTextBoxColumn1, Me.mobjDataGridViewTextBoxColumn2, Me.mobjDataGridViewTextBoxColumn3, Me.mobjDataGridViewTextBoxColumn4, Me.mobjDataGridViewTextBoxColumn5, Me.mobjDataGridViewTextBoxColumn6})
            Me.mobjDataGridView.DataSource = Me.mobjBindingSource
            Me.mobjDataGridView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDataGridView.Location = New System.Drawing.Point(0, 190)
            Me.mobjDataGridView.Name = "mobjDataGridView"
            Me.mobjDataGridView.Size = New System.Drawing.Size(830, 157)
            Me.mobjDataGridView.TabIndex = 0
            ' 
            ' mobjDataGridViewTextBoxColumn1
            ' 
            Me.mobjDataGridViewTextBoxColumn1.DataPropertyName = "ID"
            Me.mobjDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle7
            Me.mobjDataGridViewTextBoxColumn1.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn1.HeaderText = "ID"
            Me.mobjDataGridViewTextBoxColumn1.Name = "mobjDataGridViewTextBoxColumn1"
            Me.mobjDataGridViewTextBoxColumn1.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn2
            ' 
            Me.mobjDataGridViewTextBoxColumn2.DataPropertyName = "FirstName"
            Me.mobjDataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle8
            Me.mobjDataGridViewTextBoxColumn2.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn2.HeaderText = "FirstName"
            Me.mobjDataGridViewTextBoxColumn2.Name = "mobjDataGridViewTextBoxColumn2"
            Me.mobjDataGridViewTextBoxColumn2.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn3
            ' 
            Me.mobjDataGridViewTextBoxColumn3.DataPropertyName = "LastName"
            Me.mobjDataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle9
            Me.mobjDataGridViewTextBoxColumn3.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn3.HeaderText = "LastName"
            Me.mobjDataGridViewTextBoxColumn3.Name = "mobjDataGridViewTextBoxColumn3"
            Me.mobjDataGridViewTextBoxColumn3.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn4
            ' 
            Me.mobjDataGridViewTextBoxColumn4.DataPropertyName = "FullName"
            Me.mobjDataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle10
            Me.mobjDataGridViewTextBoxColumn4.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn4.HeaderText = "FullName"
            Me.mobjDataGridViewTextBoxColumn4.Name = "mobjDataGridViewTextBoxColumn4"
            Me.mobjDataGridViewTextBoxColumn4.[ReadOnly] = True
            Me.mobjDataGridViewTextBoxColumn4.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            ' 
            ' mobjDataGridViewTextBoxColumn5
            ' 
            Me.mobjDataGridViewTextBoxColumn5.DataPropertyName = "FavoriteColor"
            Me.mobjDataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle11
            Me.mobjDataGridViewTextBoxColumn5.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn5.HeaderText = "FavoriteColor"
            Me.mobjDataGridViewTextBoxColumn5.Name = "mobjDataGridViewTextBoxColumn5"
            Me.mobjDataGridViewTextBoxColumn5.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjDataGridViewTextBoxColumn5.Visible = False
            ' 
            ' mobjDataGridViewTextBoxColumn6
            ' 
            Me.mobjDataGridViewTextBoxColumn6.DataPropertyName = "Foto"
            Me.mobjDataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle12
            Me.mobjDataGridViewTextBoxColumn6.DefaultHeaderCellType = GetType(Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell)
            Me.mobjDataGridViewTextBoxColumn6.HeaderText = "Foto"
            Me.mobjDataGridViewTextBoxColumn6.Name = "mobjDataGridViewTextBoxColumn6"
            Me.mobjDataGridViewTextBoxColumn6.Resizable = Gizmox.WebGUI.Forms.DataGridViewTriState.[True]
            Me.mobjDataGridViewTextBoxColumn6.Visible = False
            ' 
            ' mobjBindingSource
            ' 
            Me.mobjBindingSource.DataSource = GetType(Utils.Customer)
            ' 
            ' mobjGroupBox
            ' 
            Me.mobjGroupBox.Controls.Add(Me.mobjTopLayoutPanel)
            Me.mobjGroupBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjGroupBox.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat
            Me.mobjGroupBox.Location = New System.Drawing.Point(0, 0)
            Me.mobjGroupBox.Name = "mobjGroupBox"
            Me.mobjGroupBox.Size = New System.Drawing.Size(830, 140)
            Me.mobjGroupBox.TabIndex = 1
            Me.mobjGroupBox.TabStop = False
            Me.mobjGroupBox.Text = "Cell Style"
            ' 
            ' mobjTopLayoutPanel
            ' 
            Me.mobjTopLayoutPanel.ColumnCount = 5
            Me.mobjTopLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjTopLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 28.0F))
            Me.mobjTopLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjTopLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjTopLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 28.0F))
            Me.mobjTopLayoutPanel.Controls.Add(Me.mobjColorsPanel, 0, 0)
            Me.mobjTopLayoutPanel.Controls.Add(Me.mobjWrapModePanel, 3, 2)
            Me.mobjTopLayoutPanel.Controls.Add(Me.mobjColorButton, 1, 0)
            Me.mobjTopLayoutPanel.Controls.Add(Me.mobjFontPanel, 3, 0)
            Me.mobjTopLayoutPanel.Controls.Add(Me.mobjFontChangeButton, 4, 0)
            Me.mobjTopLayoutPanel.Controls.Add(Me.mobjAlignmentPanel, 0, 2)
            Me.mobjTopLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjTopLayoutPanel.Location = New System.Drawing.Point(3, 17)
            Me.mobjTopLayoutPanel.Name = "mobjTopLayoutPanel"
            Me.mobjTopLayoutPanel.RowCount = 3
            Me.mobjTopLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjTopLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjTopLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjTopLayoutPanel.Size = New System.Drawing.Size(824, 120)
            Me.mobjTopLayoutPanel.TabIndex = 10
            ' 
            ' mobjColorsPanel
            ' 
            Me.mobjColorsPanel.Controls.Add(Me.mobjColorsLabel)
            Me.mobjColorsPanel.Controls.Add(Me.mobjColorComboBox)
            Me.mobjColorsPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjColorsPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjColorsPanel.Name = "mobjColorsPanel"
            Me.mobjColorsPanel.Size = New System.Drawing.Size(379, 55)
            Me.mobjColorsPanel.TabIndex = 0
            ' 
            ' mobjColorsLabel
            ' 
            Me.mobjColorsLabel.AutoSize = True
            Me.mobjColorsLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjColorsLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjColorsLabel.Name = "mobjColorsLabel"
            Me.mobjColorsLabel.Size = New System.Drawing.Size(37, 13)
            Me.mobjColorsLabel.TabIndex = 0
            Me.mobjColorsLabel.Text = "Colors"
            ' 
            ' mobjColorComboBox
            ' 
            Me.mobjColorComboBox.AllowDrag = False
            Me.mobjColorComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjColorComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjColorComboBox.Location = New System.Drawing.Point(0, 34)
            Me.mobjColorComboBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjColorComboBox.MinimumSize = New System.Drawing.Size(0, 30)
            Me.mobjColorComboBox.Name = "mobjColorComboBox"
            Me.mobjColorComboBox.Size = New System.Drawing.Size(200, 30)
            Me.mobjColorComboBox.TabIndex = 1
            ' 
            ' mobjWrapModePanel
            ' 
            Me.mobjWrapModePanel.Controls.Add(Me.wrapModeLabel)
            Me.mobjWrapModePanel.Controls.Add(Me.mobjWrapModeComboBox)
            Me.mobjWrapModePanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjWrapModePanel.Location = New System.Drawing.Point(417, 65)
            Me.mobjWrapModePanel.Name = "mobjWrapModePanel"
            Me.mobjWrapModePanel.Size = New System.Drawing.Size(379, 55)
            Me.mobjWrapModePanel.TabIndex = 0
            ' 
            ' wrapModeLabel
            ' 
            Me.wrapModeLabel.AutoSize = True
            Me.wrapModeLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.wrapModeLabel.Location = New System.Drawing.Point(0, 0)
            Me.wrapModeLabel.Name = "wrapModeLabel"
            Me.wrapModeLabel.Size = New System.Drawing.Size(59, 13)
            Me.wrapModeLabel.TabIndex = 8
            Me.wrapModeLabel.Text = "WrapMode"
            ' 
            ' mobjWrapModeComboBox
            ' 
            Me.mobjWrapModeComboBox.AllowDrag = False
            Me.mobjWrapModeComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjWrapModeComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjWrapModeComboBox.Location = New System.Drawing.Point(0, 34)
            Me.mobjWrapModeComboBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjWrapModeComboBox.MinimumSize = New System.Drawing.Size(0, 30)
            Me.mobjWrapModeComboBox.Name = "mobjWrapModeComboBox"
            Me.mobjWrapModeComboBox.Size = New System.Drawing.Size(200, 30)
            Me.mobjWrapModeComboBox.TabIndex = 9
            ' 
            ' mobjColorButton
            ' 
            Me.mobjColorButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjColorButton.Location = New System.Drawing.Point(379, 0)
            Me.mobjColorButton.Name = "mobjColorButton"
            Me.mobjColorButton.Size = New System.Drawing.Size(28, 55)
            Me.mobjColorButton.TabIndex = 2
            Me.mobjColorButton.Text = "..."
            Me.mobjColorButton.UseVisualStyleBackColor = True
            ' 
            ' mobjFontPanel
            ' 
            Me.mobjFontPanel.Controls.Add(Me.mobjFontLabel)
            Me.mobjFontPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFontPanel.Location = New System.Drawing.Point(417, 0)
            Me.mobjFontPanel.Name = "mobjFontPanel"
            Me.mobjFontPanel.Size = New System.Drawing.Size(379, 55)
            Me.mobjFontPanel.TabIndex = 0
            ' 
            ' mobjFontLabel
            ' 
            Me.mobjFontLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFontLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjFontLabel.Name = "mobjFontLabel"
            Me.mobjFontLabel.Size = New System.Drawing.Size(379, 55)
            Me.mobjFontLabel.TabIndex = 5
            Me.mobjFontLabel.Text = "Font: Tahoma, 8.25pt"
            ' 
            ' mobjFontChangeButton
            ' 
            Me.mobjFontChangeButton.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjFontChangeButton.Location = New System.Drawing.Point(796, 0)
            Me.mobjFontChangeButton.Name = "mobjFontChangeButton"
            Me.mobjFontChangeButton.Size = New System.Drawing.Size(28, 55)
            Me.mobjFontChangeButton.TabIndex = 6
            Me.mobjFontChangeButton.Text = "..."
            Me.mobjFontChangeButton.UseVisualStyleBackColor = True
            ' 
            ' mobjAlignmentPanel
            ' 
            Me.mobjAlignmentPanel.Controls.Add(Me.mobjAlignLabel)
            Me.mobjAlignmentPanel.Controls.Add(Me.mobjAlignComboBox)
            Me.mobjAlignmentPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAlignmentPanel.Location = New System.Drawing.Point(0, 65)
            Me.mobjAlignmentPanel.Name = "mobjAlignmentPanel"
            Me.mobjAlignmentPanel.Size = New System.Drawing.Size(379, 55)
            Me.mobjAlignmentPanel.TabIndex = 0
            ' 
            ' mobjAlignLabel
            ' 
            Me.mobjAlignLabel.AutoSize = True
            Me.mobjAlignLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Top
            Me.mobjAlignLabel.Location = New System.Drawing.Point(0, 0)
            Me.mobjAlignLabel.Name = "mobjAlignLabel"
            Me.mobjAlignLabel.Size = New System.Drawing.Size(54, 13)
            Me.mobjAlignLabel.TabIndex = 3
            Me.mobjAlignLabel.Text = "Alignment"
            ' 
            ' mobjAlignComboBox
            ' 
            Me.mobjAlignComboBox.AllowDrag = False
            Me.mobjAlignComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjAlignComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom
            Me.mobjAlignComboBox.Location = New System.Drawing.Point(0, 34)
            Me.mobjAlignComboBox.MaximumSize = New System.Drawing.Size(200, 0)
            Me.mobjAlignComboBox.MinimumSize = New System.Drawing.Size(0, 30)
            Me.mobjAlignComboBox.Name = "mobjAlignComboBox"
            Me.mobjAlignComboBox.Size = New System.Drawing.Size(200, 30)
            Me.mobjAlignComboBox.TabIndex = 4
            ' 
            ' mobjFontDialog
            ' 
            Me.mobjFontDialog.MaxSize = 72
            Me.mobjFontDialog.MinSize = 8
            ' 
            ' mobjDescriptionLabel
            ' 
            Me.mobjDescriptionLabel.AutoSize = True
            Me.mobjDescriptionLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDescriptionLabel.Location = New System.Drawing.Point(0, 140)
            Me.mobjDescriptionLabel.Name = "mobjDescriptionLabel"
            Me.mobjDescriptionLabel.Size = New System.Drawing.Size(830, 50)
            Me.mobjDescriptionLabel.TabIndex = 2
            Me.mobjDescriptionLabel.Text = "DataGridView demonstrates how to change the cell style"
            Me.mobjDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.ColumnCount = 1
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjGroupBox, 0, 0)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDataGridView, 0, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDescriptionLabel, 0, 1)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 3
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 140.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(830, 347)
            Me.mobjLayoutPanel.TabIndex = 3
            ' 
            ' CellStylePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(830, 347)
            Me.Text = "CellStylePage"
            DirectCast(Me.mobjDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjGroupBox.ResumeLayout(False)
            Me.mobjTopLayoutPanel.ResumeLayout(False)
            Me.mobjColorsPanel.ResumeLayout(False)
            Me.mobjWrapModePanel.ResumeLayout(False)
            Me.mobjFontPanel.ResumeLayout(False)
            Me.mobjAlignmentPanel.ResumeLayout(False)
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private WithEvents mobjDataGridView As Global.Gizmox.WebGUI.Forms.DataGridView
        Private mobjDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
        Private mobjDataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
        Private mobjBindingSource As BindingSource
        Private mobjGroupBox As Global.Gizmox.WebGUI.Forms.GroupBox
        Private mobjColorComboBox As Global.Gizmox.WebGUI.Forms.ComboBox
        Private mobjColorsLabel As Global.Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjColorDialog As ColorDialog
        Private WithEvents mobjAlignComboBox As Global.Gizmox.WebGUI.Forms.ComboBox
        Private mobjAlignLabel As Global.Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjColorButton As Global.Gizmox.WebGUI.Forms.Button
        Private WithEvents mobjFontChangeButton As Global.Gizmox.WebGUI.Forms.Button
        Private mobjFontLabel As Global.Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjFontDialog As FontDialog
        Private WithEvents mobjWrapModeComboBox As Global.Gizmox.WebGUI.Forms.ComboBox
        Private wrapModeLabel As Global.Gizmox.WebGUI.Forms.Label
        Private mobjDescriptionLabel As Label
        Private mobjTopLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Private mobjColorsPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjAlignmentPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjFontPanel As Gizmox.WebGUI.Forms.Panel
        Private mobjWrapModePanel As Gizmox.WebGUI.Forms.Panel
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel

	End Class

End Namespace
