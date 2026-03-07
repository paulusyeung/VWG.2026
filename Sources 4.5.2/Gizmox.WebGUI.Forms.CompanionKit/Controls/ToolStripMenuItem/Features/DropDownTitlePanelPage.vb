Namespace CompanionKit.Controls.ToolStripMenuItem.Features

	Public Class DropDownTitlePanelPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

        End Sub

        ''' <summary>
        ''' Handles the Load event of the DropDownTitlePanelPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub DropDownTitlePanelPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            'OnLoad Header Panel and its containment initialization: TextBox and Buttons
            mobjToolStripMenuItem1.DropDown.HeaderPanel.BackColor = Drawing.Color.Crimson
            mobjToolStripMenuItem1.DropDown.HeaderPanel.Size = New System.Drawing.Size(100, 20)
            mobjToolStripMenuItem1.DropDown.HeaderPanel.Padding = New Gizmox.WebGUI.Forms.Padding(10)
            mobjTextBox = New Gizmox.WebGUI.Forms.TextBox()
            mobjAddButton = New Gizmox.WebGUI.Forms.Button()
            mobjRemoveButton = New Gizmox.WebGUI.Forms.Button()
            mobjAddButton.Text = "Add"
            mobjAddButton.Size = New System.Drawing.Size(1, 25)
            mobjRemoveButton.Text = "Remove"
            mobjRemoveButton.Size = New System.Drawing.Size(1, 25)
            mobjRemoveButton.Dock = DockStyle.Top
            mobjAddButton.Dock = DockStyle.Top
            mobjTextBox.Text = "NewItem"
            mobjTextBox.Size = New System.Drawing.Size(1, 25)
            mobjTextBox.Dock = DockStyle.Top
            mobjToolStripMenuItem1.DropDown.HeaderPanel.Controls.Add(mobjRemoveButton)
            mobjToolStripMenuItem1.DropDown.HeaderPanel.Controls.Add(mobjAddButton)
            mobjToolStripMenuItem1.DropDown.HeaderPanel.Controls.Add(mobjTextBox)
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjRemoveButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjRemoveButton_Click(sender As Object, e As EventArgs) Handles mobjRemoveButton.Click
            'Removes last non-default item
            If mobjToolStripMenuItem1.DropDownItems.Count > 5 Then
                mobjToolStripMenuItem1.DropDownItems.RemoveAt(mobjToolStripMenuItem1.DropDownItems.Count - 1)
            End If
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjAddButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjAddButton_Click(sender As Object, e As EventArgs) Handles mobjAddButton.Click
            'If textBox's text is not empty - add new item with name from textbox
            If Not String.IsNullOrEmpty(mobjTextBox.Text) Then
                mobjToolStripMenuItem1.DropDownItems.Add(mobjTextBox.Text, Nothing, AddressOf ShowMessage)
            End If
        End Sub

        ''' <summary>
        ''' Shows the message.
        ''' </summary>
        ''' <param name="sender">The sender.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub ShowMessage(sender As Object, e As EventArgs)
            'Shows message, which displays current toolStripMenuItem (non-default)
            MessageBox.Show("You clicked on " + DirectCast(sender, ToolStripItem).Text)
        End Sub

	End Class

End Namespace