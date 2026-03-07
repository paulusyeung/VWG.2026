Imports CompanionKit.Controls.Utils

Namespace CompanionKit.Controls.ComboBox.Appearance

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class TextWithImagePage
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
            Me.mobjBindingSource = New Gizmox.WebGUI.Forms.BindingSource(Me.components)
            Me.mobjImageMemberLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjValueMemberLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjDisplayMemberLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjImageMemberTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjValueMemberTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjDisplayMemberTextBox = New Gizmox.WebGUI.Forms.TextBox()
            Me.mobjLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjComboBox = New Gizmox.WebGUI.Forms.ComboBox()
            Me.mobjErrorProvider = New Gizmox.WebGUI.Forms.ErrorProvider(Me.components)
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjBindingSource
            ' 
            Me.mobjBindingSource.DataSource = GetType(System.Collections.Generic.List(Of Customer))
            ' 
            ' mobjImageMemberLabel
            ' 
            Me.mobjImageMemberLabel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjImageMemberLabel, 3)
            Me.mobjImageMemberLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjImageMemberLabel.Location = New System.Drawing.Point(0, 256)
            Me.mobjImageMemberLabel.Name = "mobjImageMemberLabel"
            Me.mobjImageMemberLabel.Size = New System.Drawing.Size(337, 40)
            Me.mobjImageMemberLabel.TabIndex = 7
            Me.mobjImageMemberLabel.Text = "ImageMember"
            Me.mobjImageMemberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjValueMemberLabel
            ' 
            Me.mobjValueMemberLabel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjValueMemberLabel, 3)
            Me.mobjValueMemberLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjValueMemberLabel.Location = New System.Drawing.Point(0, 176)
            Me.mobjValueMemberLabel.Name = "mobjValueMemberLabel"
            Me.mobjValueMemberLabel.Size = New System.Drawing.Size(337, 40)
            Me.mobjValueMemberLabel.TabIndex = 6
            Me.mobjValueMemberLabel.Text = "ValueMember"
            Me.mobjValueMemberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjDisplayMemberLabel
            ' 
            Me.mobjDisplayMemberLabel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjDisplayMemberLabel, 3)
            Me.mobjDisplayMemberLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDisplayMemberLabel.Location = New System.Drawing.Point(0, 96)
            Me.mobjDisplayMemberLabel.Name = "mobjDisplayMemberLabel"
            Me.mobjDisplayMemberLabel.Size = New System.Drawing.Size(337, 40)
            Me.mobjDisplayMemberLabel.TabIndex = 5
            Me.mobjDisplayMemberLabel.Text = "DisplayMember"
            Me.mobjDisplayMemberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjImageMemberTextBox
            ' 
            Me.mobjImageMemberTextBox.AllowDrag = False
            Me.mobjImageMemberTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjImageMemberTextBox.Location = New System.Drawing.Point(71, 299)
            Me.mobjImageMemberTextBox.Name = "mobjImageMemberTextBox"
            Me.mobjImageMemberTextBox.Size = New System.Drawing.Size(194, 24)
            Me.mobjImageMemberTextBox.TabIndex = 4
            Me.mobjImageMemberTextBox.Text = "Foto"
            ' 
            ' mobjValueMemberTextBox
            ' 
            Me.mobjValueMemberTextBox.AllowDrag = False
            Me.mobjValueMemberTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjValueMemberTextBox.Location = New System.Drawing.Point(71, 219)
            Me.mobjValueMemberTextBox.Name = "mobjValueMemberTextBox"
            Me.mobjValueMemberTextBox.Size = New System.Drawing.Size(194, 24)
            Me.mobjValueMemberTextBox.TabIndex = 3
            Me.mobjValueMemberTextBox.Text = "ID"
            ' 
            ' mobjDisplayMemberTextBox
            ' 
            Me.mobjDisplayMemberTextBox.AllowDrag = False
            Me.mobjDisplayMemberTextBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjDisplayMemberTextBox.Location = New System.Drawing.Point(71, 139)
            Me.mobjDisplayMemberTextBox.Name = "mobjDisplayMemberTextBox"
            Me.mobjDisplayMemberTextBox.Size = New System.Drawing.Size(194, 24)
            Me.mobjDisplayMemberTextBox.TabIndex = 2
            Me.mobjDisplayMemberTextBox.Text = "FullName"
            ' 
            ' mobjLabel
            ' 
            Me.mobjLabel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjLabel, 3)
            Me.mobjLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel.Location = New System.Drawing.Point(0, 16)
            Me.mobjLabel.Name = "mobjLabel"
            Me.mobjLabel.Size = New System.Drawing.Size(337, 40)
            Me.mobjLabel.TabIndex = 1
            Me.mobjLabel.Text = "ComboBox with Image"
            Me.mobjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjComboBox
            ' 
            Me.mobjComboBox.AllowDrag = False
            Me.mobjComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.mobjComboBox.DataSource = Me.mobjBindingSource
            Me.mobjComboBox.DisplayMember = "FullName"
            Me.mobjComboBox.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjComboBox.ImageMember = "Foto"
            Me.mobjComboBox.Location = New System.Drawing.Point(68, 56)
            Me.mobjComboBox.Name = "mobjComboBox"
            Me.mobjComboBox.Size = New System.Drawing.Size(200, 21)
            Me.mobjComboBox.TabIndex = 0
            Me.mobjComboBox.ValueMember = "ID"
            ' 
            ' mobjErrorProvider
            ' 
            Me.mobjErrorProvider.BlinkRate = 3
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjLayoutPanel.ColumnCount = 3
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 200.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjImageMemberTextBox, 1, 11)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjValueMemberTextBox, 1, 8)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDisplayMemberTextBox, 1, 5)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjComboBox, 1, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjLabel, 0, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjDisplayMemberLabel, 0, 4)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjValueMemberLabel, 0, 7)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjImageMemberLabel, 0, 10)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 13
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 10.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 40.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(337, 342)
            Me.mobjLayoutPanel.TabIndex = 8
            ' 
            ' TextWithImagePage
            ' 
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(337, 342)
            Me.Text = "TextWithImagePage"
            DirectCast(Me.mobjBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjBindingSource As Gizmox.WebGUI.Forms.BindingSource
        Private mobjImageMemberLabel As Gizmox.WebGUI.Forms.Label
        Private mobjValueMemberLabel As Gizmox.WebGUI.Forms.Label
        Private mobjDisplayMemberLabel As Gizmox.WebGUI.Forms.Label
        Private WithEvents mobjImageMemberTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjValueMemberTextBox As Gizmox.WebGUI.Forms.TextBox
        Private WithEvents mobjDisplayMemberTextBox As Gizmox.WebGUI.Forms.TextBox
        Private mobjLabel As Gizmox.WebGUI.Forms.Label
        Private mobjComboBox As Gizmox.WebGUI.Forms.ComboBox
        Private mobjErrorProvider As Gizmox.WebGUI.Forms.ErrorProvider
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel


    End Class

End Namespace
