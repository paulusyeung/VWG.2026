Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Namespace WebSocketsSampleAppsVB
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DynamicDataForm
        Inherits Gizmox.WebGUI.Forms.Form

        'Form overrides dispose to clean up the component list.
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
            Me.mobjProgressBar1 = New Gizmox.WebGUI.Forms.ProgressBar()
            Me.mobjProgressBar2 = New Gizmox.WebGUI.Forms.ProgressBar()
            Me.mobjProgressBar3 = New Gizmox.WebGUI.Forms.ProgressBar()
            Me.mobjProgressBar4 = New Gizmox.WebGUI.Forms.ProgressBar()
            Me.mobjProgressBar5 = New Gizmox.WebGUI.Forms.ProgressBar()
            Me.mobjLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjInfoLabel = New Gizmox.WebGUI.Forms.Label()
            Me.mobjAdditionalLayoutPanel = New Gizmox.WebGUI.Forms.TableLayoutPanel()
            Me.mobjLabel5 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLabel4 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLabel3 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLabel2 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLabel1 = New Gizmox.WebGUI.Forms.Label()
            Me.mobjLayoutPanel.SuspendLayout()
            Me.mobjAdditionalLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mobjProgressBar1
            ' 
            Me.mobjProgressBar1.ClientId = "ProgressBar1"
            Me.mobjProgressBar1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjProgressBar1.Location = New System.Drawing.Point(0, 15)
            Me.mobjProgressBar1.Name = "progressBar1"
            Me.mobjProgressBar1.Size = New System.Drawing.Size(300, 30)
            Me.mobjProgressBar1.TabIndex = 0
            Me.mobjProgressBar1.Tag = "ProgressBar1"
            ' 
            ' mobjProgressBar2
            ' 
            Me.mobjProgressBar2.ClientId = "ProgressBar2"
            Me.mobjProgressBar2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjProgressBar2.Location = New System.Drawing.Point(0, 75)
            Me.mobjProgressBar2.Name = "progressBar2"
            Me.mobjProgressBar2.Size = New System.Drawing.Size(300, 30)
            Me.mobjProgressBar2.TabIndex = 1
            Me.mobjProgressBar2.Tag = "ProgressBar2"
            ' 
            ' mobjProgressBar3
            ' 
            Me.mobjProgressBar3.ClientId = "ProgressBar3"
            Me.mobjProgressBar3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjProgressBar3.Location = New System.Drawing.Point(0, 135)
            Me.mobjProgressBar3.Name = "progressBar3"
            Me.mobjProgressBar3.Size = New System.Drawing.Size(300, 30)
            Me.mobjProgressBar3.TabIndex = 1
            Me.mobjProgressBar3.Tag = "ProgressBar4"
            ' 
            ' mobjProgressBar4
            ' 
            Me.mobjProgressBar4.ClientId = "ProgressBar4"
            Me.mobjProgressBar4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjProgressBar4.Location = New System.Drawing.Point(0, 195)
            Me.mobjProgressBar4.Name = "progressBar4"
            Me.mobjProgressBar4.Size = New System.Drawing.Size(300, 30)
            Me.mobjProgressBar4.TabIndex = 0
            Me.mobjProgressBar4.Tag = "ProgressBar3"
            ' 
            ' mobjProgressBar5
            ' 
            Me.mobjProgressBar5.ClientId = "ProgressBar5"
            Me.mobjProgressBar5.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjProgressBar5.Location = New System.Drawing.Point(0, 255)
            Me.mobjProgressBar5.Name = "progressBar5"
            Me.mobjProgressBar5.Size = New System.Drawing.Size(300, 30)
            Me.mobjProgressBar5.TabIndex = 1
            Me.mobjProgressBar5.Tag = "ProgressBar5"
            ' 
            ' mobjLayoutPanel
            ' 
            Me.mobjLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjLayoutPanel.ColumnCount = 7
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 60.0F))
            Me.mobjLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Controls.Add(Me.mobjInfoLabel, 1, 1)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjAdditionalLayoutPanel, 1, 3)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjLabel5, 5, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjLabel4, 4, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjLabel3, 3, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjLabel2, 2, 2)
            Me.mobjLayoutPanel.Controls.Add(Me.mobjLabel1, 1, 2)
            Me.mobjLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.mobjLayoutPanel.Name = "mobjLayoutPanel"
            Me.mobjLayoutPanel.RowCount = 5
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 300.0F))
            Me.mobjLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 50.0F))
            Me.mobjLayoutPanel.Size = New System.Drawing.Size(852, 391)
            Me.mobjLayoutPanel.TabIndex = 2
            Me.mobjLayoutPanel.VisualEffect = New Gizmox.WebGUI.Forms.VisualEffects.EmptyVisualEffect()
            ' 
            ' mobjInfoLabel
            ' 
            Me.mobjInfoLabel.AutoSize = True
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjInfoLabel, 5)
            Me.mobjInfoLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjInfoLabel.Location = New System.Drawing.Point(276, 15)
            Me.mobjInfoLabel.Name = "mobjInfoLabel"
            Me.mobjInfoLabel.Size = New System.Drawing.Size(300, 30)
            Me.mobjInfoLabel.TabIndex = 0
            Me.mobjInfoLabel.Text = "Dynamic data columns:"
            Me.mobjInfoLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
            ' 
            ' mobjAdditionalLayoutPanel
            ' 
            Me.mobjAdditionalLayoutPanel.BorderColor = System.Drawing.Color.FromArgb(CInt(CByte(101)), CInt(CByte(147)), CInt(CByte(207)))
            Me.mobjAdditionalLayoutPanel.ColumnCount = 1
            Me.mobjLayoutPanel.SetColumnSpan(Me.mobjAdditionalLayoutPanel, 5)
            Me.mobjAdditionalLayoutPanel.ColumnStyles.Add(New Gizmox.WebGUI.Forms.ColumnStyle(Gizmox.WebGUI.Forms.SizeType.Percent, 100.0F))
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjProgressBar1, 0, 1)
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjProgressBar5, 0, 9)
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjProgressBar2, 0, 3)
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjProgressBar3, 0, 5)
            Me.mobjAdditionalLayoutPanel.Controls.Add(Me.mobjProgressBar4, 0, 7)
            Me.mobjAdditionalLayoutPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjAdditionalLayoutPanel.Location = New System.Drawing.Point(276, 75)
            Me.mobjAdditionalLayoutPanel.Name = "mobjAdditionalLayoutPanel"
            Me.mobjAdditionalLayoutPanel.RowCount = 11
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 15.0F))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 30.0F))
            Me.mobjAdditionalLayoutPanel.RowStyles.Add(New Gizmox.WebGUI.Forms.RowStyle(Gizmox.WebGUI.Forms.SizeType.Absolute, 15.0F))
            Me.mobjAdditionalLayoutPanel.Size = New System.Drawing.Size(300, 300)
            Me.mobjAdditionalLayoutPanel.TabIndex = 0
            Me.mobjAdditionalLayoutPanel.VisualEffect = New Gizmox.WebGUI.Forms.VisualEffects.TransformVisualEffect(New Gizmox.WebGUI.Forms.VisualEffects.Transformation() {New Gizmox.WebGUI.Forms.VisualEffects.Transformation(Gizmox.WebGUI.Forms.VisualEffects.TransformType.Rotate, 270.0F, New Gizmox.WebGUI.Forms.VisualEffects.Matrix(1.0F, 0.0F, 0.0F, 1.0F, 0.0F, 0.0F), Nothing, Nothing, New Gizmox.WebGUI.Forms.VisualEffects.AxisValue(), _
             New Gizmox.WebGUI.Forms.VisualEffects.AxisLengthAndUnits(Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Nothing, Nothing, Nothing))}, New Gizmox.WebGUI.Forms.VisualEffects.Location(Gizmox.WebGUI.Forms.VisualEffects.HorizontalDirection.None, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Percent, Gizmox.WebGUI.Forms.VisualEffects.VerticalDirection.None, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Percent, 50.0F, 50.0F))
            ' 
            ' mobjLabel5
            ' 
            Me.mobjLabel5.AutoSize = True
            Me.mobjLabel5.ClientId = "Label5"
            Me.mobjLabel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel5.Location = New System.Drawing.Point(516, 45)
            Me.mobjLabel5.Name = "label5"
            Me.mobjLabel5.Size = New System.Drawing.Size(60, 30)
            Me.mobjLabel5.TabIndex = 0
            Me.mobjLabel5.Text = "0"
            Me.mobjLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjLabel4
            ' 
            Me.mobjLabel4.AutoSize = True
            Me.mobjLabel4.ClientId = "Label4"
            Me.mobjLabel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel4.Location = New System.Drawing.Point(456, 45)
            Me.mobjLabel4.Name = "label4"
            Me.mobjLabel4.Size = New System.Drawing.Size(60, 30)
            Me.mobjLabel4.TabIndex = 0
            Me.mobjLabel4.Text = "0"
            Me.mobjLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjLabel3
            ' 
            Me.mobjLabel3.AutoSize = True
            Me.mobjLabel3.ClientId = "Label3"
            Me.mobjLabel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel3.Location = New System.Drawing.Point(396, 45)
            Me.mobjLabel3.Name = "label3"
            Me.mobjLabel3.Size = New System.Drawing.Size(60, 30)
            Me.mobjLabel3.TabIndex = 0
            Me.mobjLabel3.Text = "0"
            Me.mobjLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjLabel2
            ' 
            Me.mobjLabel2.AutoSize = True
            Me.mobjLabel2.ClientId = "Label2"
            Me.mobjLabel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel2.Location = New System.Drawing.Point(336, 45)
            Me.mobjLabel2.Name = "label2"
            Me.mobjLabel2.Size = New System.Drawing.Size(60, 30)
            Me.mobjLabel2.TabIndex = 0
            Me.mobjLabel2.Text = "0"
            Me.mobjLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' mobjLabel1
            ' 
            Me.mobjLabel1.AutoSize = True
            Me.mobjLabel1.ClientId = "Label1"
            Me.mobjLabel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill
            Me.mobjLabel1.Location = New System.Drawing.Point(276, 45)
            Me.mobjLabel1.Name = "label1"
            Me.mobjLabel1.Size = New System.Drawing.Size(60, 30)
            Me.mobjLabel1.TabIndex = 0
            Me.mobjLabel1.Text = "0"
            Me.mobjLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            ' 
            ' DynamicDataPage
            ' 
            Me.ClientId = "page"
            Me.Controls.Add(Me.mobjLayoutPanel)
            Me.Size = New System.Drawing.Size(852, 391)
            Me.Text = "DynamicData"
            Me.VisualEffect = New Gizmox.WebGUI.Forms.VisualEffects.EmptyVisualEffect()
            Me.mobjLayoutPanel.ResumeLayout(False)
            Me.mobjAdditionalLayoutPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Private mobjLabel1 As Gizmox.WebGUI.Forms.Label
        Private mobjLabel2 As Gizmox.WebGUI.Forms.Label
        Private mobjLabel3 As Gizmox.WebGUI.Forms.Label
        Private mobjLabel4 As Gizmox.WebGUI.Forms.Label
        Private mobjLabel5 As Gizmox.WebGUI.Forms.Label
        Private mobjLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Friend mobjAdditionalLayoutPanel As Gizmox.WebGUI.Forms.TableLayoutPanel
        Friend mobjProgressBar1 As Gizmox.WebGUI.Forms.ProgressBar
        Friend mobjProgressBar2 As Gizmox.WebGUI.Forms.ProgressBar
        Friend mobjProgressBar3 As Gizmox.WebGUI.Forms.ProgressBar
        Friend mobjProgressBar4 As Gizmox.WebGUI.Forms.ProgressBar
        Friend mobjProgressBar5 As Gizmox.WebGUI.Forms.ProgressBar
        Private mobjInfoLabel As Gizmox.WebGUI.Forms.Label

    End Class
End Namespace