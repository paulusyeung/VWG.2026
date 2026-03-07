Namespace CompanionKit.Controls.DataGridView.PopulatingData

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class UserForm
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
            Me.UserIDLabel = New Global.Gizmox.WebGUI.Forms.Label
            Me.UserIDTextBox = New Global.Gizmox.WebGUI.Forms.TextBox
            Me.UserNameLabel = New Global.Gizmox.WebGUI.Forms.Label
            Me.userNameTextBox = New Global.Gizmox.WebGUI.Forms.TextBox
            Me.EmailLabel = New Global.Gizmox.WebGUI.Forms.Label
            Me.EmailTextBox = New Global.Gizmox.WebGUI.Forms.TextBox
            Me.PhoneLabel = New Global.Gizmox.WebGUI.Forms.Label
            Me.PhoneTextBox = New Global.Gizmox.WebGUI.Forms.TextBox
            Me.AddressLabel = New Global.Gizmox.WebGUI.Forms.Label
            Me.AddressTextBox = New Global.Gizmox.WebGUI.Forms.TextBox
            Me.CountryLabel = New Global.Gizmox.WebGUI.Forms.Label
            Me.CountryTextBox = New Global.Gizmox.WebGUI.Forms.TextBox
            Me.CityLabel = New Global.Gizmox.WebGUI.Forms.Label
            Me.cityTextBox = New Global.Gizmox.WebGUI.Forms.TextBox
            Me.StateLabel = New Global.Gizmox.WebGUI.Forms.Label
            Me.StateTextBox = New Global.Gizmox.WebGUI.Forms.TextBox
            Me.ZipCodeLabel = New Global.Gizmox.WebGUI.Forms.Label
            Me.ZipCodeTextBox = New Global.Gizmox.WebGUI.Forms.TextBox
            Me.okBtn = New Global.Gizmox.WebGUI.Forms.Button
            Me.CancelBtn = New Global.Gizmox.WebGUI.Forms.Button
            Me.SuspendLayout()
            '
            'UserIDLabel
            '
            Me.UserIDLabel.AutoSize = True
            Me.UserIDLabel.Location = New System.Drawing.Point(24, 34)
            Me.UserIDLabel.Name = "UserIDLabel"
            Me.UserIDLabel.Size = New System.Drawing.Size(38, 13)
            Me.UserIDLabel.TabIndex = 0
            Me.UserIDLabel.Text = "User ID"
            '
            'UserIDTextBox
            '
            Me.UserIDTextBox.BorderStyle = Global.Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.UserIDTextBox.ReadOnly = True
            Me.UserIDTextBox.Location = New System.Drawing.Point(78, 30)
            Me.UserIDTextBox.Name = "UserIDTextBox"
            Me.UserIDTextBox.Size = New System.Drawing.Size(130, 20)
            Me.UserIDTextBox.TabIndex = 1
            '
            'UserNameLabel
            '
            Me.UserNameLabel.AutoSize = True
            Me.UserNameLabel.Location = New System.Drawing.Point(216, 34)
            Me.UserNameLabel.Name = "UserNameLabel"
            Me.UserNameLabel.Size = New System.Drawing.Size(38, 13)
            Me.UserNameLabel.TabIndex = 2
            Me.UserNameLabel.Text = "User Name"
            '
            'userNameTextBox
            '
            Me.userNameTextBox.BorderStyle = Global.Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.userNameTextBox.Location = New System.Drawing.Point(281, 30)
            Me.userNameTextBox.Name = "userNameTextBox"
            Me.userNameTextBox.Size = New System.Drawing.Size(150, 20)
            Me.userNameTextBox.TabIndex = 3
            '
            'EmailLabel
            '
            Me.EmailLabel.AutoSize = True
            Me.EmailLabel.Location = New System.Drawing.Point(24, 71)
            Me.EmailLabel.Name = "EmailLabel"
            Me.EmailLabel.Size = New System.Drawing.Size(38, 13)
            Me.EmailLabel.TabIndex = 4
            Me.EmailLabel.Text = "E-mail"
            '
            'EmailTextBox
            '
            Me.EmailTextBox.BorderStyle = Global.Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.EmailTextBox.Location = New System.Drawing.Point(77, 67)
            Me.EmailTextBox.Name = "EmailTextBox"
            Me.EmailTextBox.Size = New System.Drawing.Size(130, 20)
            Me.EmailTextBox.TabIndex = 5
            '
            'PhoneLabel
            '
            Me.PhoneLabel.AutoSize = True
            Me.PhoneLabel.Location = New System.Drawing.Point(216, 71)
            Me.PhoneLabel.Name = "PhoneLabel"
            Me.PhoneLabel.Size = New System.Drawing.Size(38, 13)
            Me.PhoneLabel.TabIndex = 6
            Me.PhoneLabel.Text = "Phone"
            '
            'PhoneTextBox
            '
            Me.PhoneTextBox.BorderStyle = Global.Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.PhoneTextBox.Location = New System.Drawing.Point(281, 67)
            Me.PhoneTextBox.Name = "PhoneTextBox"
            Me.PhoneTextBox.Size = New System.Drawing.Size(150, 20)
            Me.PhoneTextBox.TabIndex = 7
            '
            'AddressLabel
            '
            Me.AddressLabel.AutoSize = True
            Me.AddressLabel.Location = New System.Drawing.Point(24, 108)
            Me.AddressLabel.Name = "AddressLabel"
            Me.AddressLabel.Size = New System.Drawing.Size(38, 13)
            Me.AddressLabel.TabIndex = 8
            Me.AddressLabel.Text = "Address"
            '
            'AddressTextBox
            '
            Me.AddressTextBox.BorderStyle = Global.Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.AddressTextBox.Location = New System.Drawing.Point(78, 104)
            Me.AddressTextBox.Name = "AddressTextBox"
            Me.AddressTextBox.Size = New System.Drawing.Size(353, 20)
            Me.AddressTextBox.TabIndex = 9
            '
            'CountryLabel
            '
            Me.CountryLabel.AutoSize = True
            Me.CountryLabel.Location = New System.Drawing.Point(24, 145)
            Me.CountryLabel.Name = "CountryLabel"
            Me.CountryLabel.Size = New System.Drawing.Size(38, 13)
            Me.CountryLabel.TabIndex = 10
            Me.CountryLabel.Text = "Country"
            '
            'CountryTextBox
            '
            Me.CountryTextBox.BorderStyle = Global.Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.CountryTextBox.Location = New System.Drawing.Point(78, 141)
            Me.CountryTextBox.Name = "CountryTextBox"
            Me.CountryTextBox.Size = New System.Drawing.Size(130, 20)
            Me.CountryTextBox.TabIndex = 11
            '
            'CityLabel
            '
            Me.CityLabel.AutoSize = True
            Me.CityLabel.Location = New System.Drawing.Point(216, 145)
            Me.CityLabel.Name = "CityLabel"
            Me.CityLabel.Size = New System.Drawing.Size(38, 13)
            Me.CityLabel.TabIndex = 12
            Me.CityLabel.Text = "City"
            '
            'cityTextBox
            '
            Me.cityTextBox.BorderStyle = Global.Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.cityTextBox.Location = New System.Drawing.Point(281, 141)
            Me.cityTextBox.Name = "cityTextBox"
            Me.cityTextBox.Size = New System.Drawing.Size(150, 20)
            Me.cityTextBox.TabIndex = 13
            '
            'StateLabel
            '
            Me.StateLabel.AutoSize = True
            Me.StateLabel.Location = New System.Drawing.Point(24, 182)
            Me.StateLabel.Name = "StateLabel"
            Me.StateLabel.Size = New System.Drawing.Size(38, 13)
            Me.StateLabel.TabIndex = 14
            Me.StateLabel.Text = "State"
            '
            'StateTextBox
            '
            Me.StateTextBox.BorderStyle = Global.Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.StateTextBox.Location = New System.Drawing.Point(78, 178)
            Me.StateTextBox.Name = "StateTextBox"
            Me.StateTextBox.Size = New System.Drawing.Size(130, 20)
            Me.StateTextBox.TabIndex = 15
            '
            'ZipCodeLabel
            '
            Me.ZipCodeLabel.AutoSize = True
            Me.ZipCodeLabel.Location = New System.Drawing.Point(216, 182)
            Me.ZipCodeLabel.Name = "ZipCodeLabel"
            Me.ZipCodeLabel.Size = New System.Drawing.Size(38, 13)
            Me.ZipCodeLabel.TabIndex = 16
            Me.ZipCodeLabel.Text = "ZipCode"
            '
            'ZipCodeTextBox
            '
            Me.ZipCodeTextBox.BorderStyle = Global.Gizmox.WebGUI.Forms.BorderStyle.Fixed3D
            Me.ZipCodeTextBox.Location = New System.Drawing.Point(281, 178)
            Me.ZipCodeTextBox.Name = "ZipCodeTextBox"
            Me.ZipCodeTextBox.Size = New System.Drawing.Size(150, 20)
            Me.ZipCodeTextBox.TabIndex = 17
            '
            'okBtn
            '
            Me.okBtn.Location = New System.Drawing.Point(133, 222)
            Me.okBtn.Name = "okBtn"
            Me.okBtn.Size = New System.Drawing.Size(75, 23)
            Me.okBtn.TabIndex = 18
            Me.okBtn.Text = "Ok"
            Me.okBtn.UseVisualStyleBackColor = True
            '
            'CancelBtn
            '
            Me.CancelBtn.Location = New System.Drawing.Point(258, 222)
            Me.CancelBtn.Name = "CancelBtn"
            Me.CancelBtn.Size = New System.Drawing.Size(75, 23)
            Me.CancelBtn.TabIndex = 19
            Me.CancelBtn.Text = "Cancel"
            Me.CancelBtn.UseVisualStyleBackColor = True
            '
            'UserForm
            '
            Me.Controls.Add(Me.CancelBtn)
            Me.Controls.Add(Me.okBtn)
            Me.Controls.Add(Me.ZipCodeTextBox)
            Me.Controls.Add(Me.ZipCodeLabel)
            Me.Controls.Add(Me.StateTextBox)
            Me.Controls.Add(Me.StateLabel)
            Me.Controls.Add(Me.cityTextBox)
            Me.Controls.Add(Me.CityLabel)
            Me.Controls.Add(Me.CountryTextBox)
            Me.Controls.Add(Me.CountryLabel)
            Me.Controls.Add(Me.AddressTextBox)
            Me.Controls.Add(Me.AddressLabel)
            Me.Controls.Add(Me.PhoneTextBox)
            Me.Controls.Add(Me.PhoneLabel)
            Me.Controls.Add(Me.EmailTextBox)
            Me.Controls.Add(Me.EmailLabel)
            Me.Controls.Add(Me.userNameTextBox)
            Me.Controls.Add(Me.UserNameLabel)
            Me.Controls.Add(Me.UserIDTextBox)
            Me.Controls.Add(Me.UserIDLabel)
            Me.Size = New System.Drawing.Size(463, 264)
            Me.Text = "UserForm"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents UserIDLabel As Global.Gizmox.WebGUI.Forms.Label
        Friend WithEvents UserIDTextBox As Global.Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents UserNameLabel As Global.Gizmox.WebGUI.Forms.Label
        Friend WithEvents userNameTextBox As Global.Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents EmailLabel As Global.Gizmox.WebGUI.Forms.Label
        Friend WithEvents EmailTextBox As Global.Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents PhoneLabel As Global.Gizmox.WebGUI.Forms.Label
        Friend WithEvents PhoneTextBox As Global.Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents AddressLabel As Global.Gizmox.WebGUI.Forms.Label
        Friend WithEvents AddressTextBox As Global.Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents CountryLabel As Global.Gizmox.WebGUI.Forms.Label
        Friend WithEvents CountryTextBox As Global.Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents CityLabel As Global.Gizmox.WebGUI.Forms.Label
        Friend WithEvents cityTextBox As Global.Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents StateLabel As Global.Gizmox.WebGUI.Forms.Label
        Friend WithEvents StateTextBox As Global.Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents ZipCodeLabel As Global.Gizmox.WebGUI.Forms.Label
        Friend WithEvents ZipCodeTextBox As Global.Gizmox.WebGUI.Forms.TextBox
        Friend WithEvents okBtn As Global.Gizmox.WebGUI.Forms.Button
        Friend WithEvents CancelBtn As Global.Gizmox.WebGUI.Forms.Button

    End Class
End Namespace