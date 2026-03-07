Namespace CompanionKit.Controls.Panel.Appearance

	Public Class AutoSizePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()



		End Sub

        ''' <summary>
        ''' Adds a button to demonstrated panel
        ''' </summary>
        ''' <remarks></remarks>
		Private Sub AddNewButtonToPanel()
			Dim button As New Global.Gizmox.WebGUI.Forms.Button
            button.Text = String.Format("Button {0}", (Me.mobjPanel.Controls.Count + 1))
            button.Left = (Me.mobjPanel.Controls.Count * (button.Width + 10))
            Me.mobjPanel.Controls.Add(button)
		End Sub


        ''' <summary>
        ''' Updates maximum size for demonstrated panel
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub UpdatePanelMaximumSize()

            Dim panelMaxWidth As Integer = 1000
            Dim panelMaxHeight As Integer = 250
            Me.mobjPanel.MaximumSize = New Drawing.Size(panelMaxWidth, panelMaxHeight)

        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjButton.Click
            AddNewButtonToPanel()
        End Sub

        ''' <summary>
        ''' Handles the Load event of the AutoSizePage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		Private Sub AutoSizePage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			UpdatePanelMaximumSize()
            AddNewButtonToPanel()
            Me.mobjAutoSizeCB.Checked = Me.mobjPanel.AutoSize
        End Sub

        ''' <summary>
        ''' Handles the Resize event of the AutoSizePage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub AutoSizePage_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
            UpdatePanelMaximumSize()
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the CheckBox1 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjAutoSizeCB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mobjAutoSizeCB.CheckedChanged
            Me.mobjPanel.AutoSize = Me.mobjAutoSizeCB.Checked
        End Sub
    End Class

End Namespace
