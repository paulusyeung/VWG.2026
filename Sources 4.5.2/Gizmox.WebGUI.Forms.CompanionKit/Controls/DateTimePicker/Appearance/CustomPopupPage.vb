Namespace CompanionKit.Controls.DateTimePicker.Appearance

	Public Class CustomPopupPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles the Load event of the CustomPopupPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub CustomPopupPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            'Creates new CustomDateTimePicker instance and adds to the form
            Dim mobjCustomDateTimePicker As New CustomDateTimePicker()
            mobjCustomDateTimePicker.Location = New Drawing.Point(20, 20)
            mobjCustomDateTimePicker.Dock = DockStyle.Fill
            'this.Controls.Add(mobjCustomDateTimePicker);
            Me.mobjLayoutPanel.Controls.Add(mobjCustomDateTimePicker, 1, 1)
        End Sub
    End Class

    Public Class CustomDateTimePicker
        Inherits Gizmox.WebGUI.Forms.DateTimePicker
        'Instance of DateTimePicker
        Private mobjCustomDTP As CustomDateTimePicker

        ''' <summary>
        ''' Gets the date time picker popup.
        ''' </summary>
        ''' <returns></returns>
        Protected Overrides Function GetDateTimePickerPopup() As DateTimePickerPopup
            Return ModifyInstance(MyBase.GetDateTimePickerPopup())
        End Function

        ''' <summary>
        ''' Modifies the instance.
        ''' </summary>
        ''' <param name="objInstance">The obj instance.</param>
        ''' <returns></returns>
        Private Function ModifyInstance(objInstance As DateTimePickerPopup) As DateTimePickerPopup
            'Creates and sets up button control
            Dim mobjInternalButton As New Gizmox.WebGUI.Forms.Button()
            mobjInternalButton.Text = "Set current date"
            mobjInternalButton.Size = New Drawing.Size(50, 50)
            mobjInternalButton.Dock = DockStyle.Top
            AddHandler mobjInternalButton.Click, AddressOf mobjInternalButton_Click
            'Adds button to DTP control
            objInstance.Controls.Add(mobjInternalButton)
            'Sets size DTP
            objInstance.Size = New Drawing.Size(300, 250)
            'Sets background image of DTP control
            objInstance.Controls(0).BackgroundImageLayout = ImageLayout.Stretch
            objInstance.Controls(0).BackgroundImage = "Images.DTPBackground.jpg"
            objInstance.Controls(0).BackColor = Drawing.Color.Aqua
            'Updates control
            objInstance.Update()
            Me.mobjCustomDTP = Me
            Return objInstance
        End Function

        ''' <summary>
        ''' Handles the Click event of the mobjInternalButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjInternalButton_Click(sender As Object, e As EventArgs)
            'Sets current time to DTP
            Me.mobjCustomDTP.Value = DateTime.Now
        End Sub

    End Class

End Namespace