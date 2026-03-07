Imports Gizmox.WebGUI.Forms.Client

Namespace CompanionKit.Concepts.ClientAPI.ChangingDockStyle

	Public Class DockStylesPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub

        ''' <summary>
        ''' Sets the dock style.
        ''' </summary>
        ''' <param name="objClientContext">The obj client context.</param>
        ''' <param name="objStyle">The dock style.</param>
        Private Sub SetDockStyle(objClientContext As ClientContext, objStyle As DockStyle)
            '     Invoking js callback function with DockStyle parameter as a string.
            objClientContext.Invoke("setDockStyle", objStyle.ToString().ToLower())
        End Sub

        ''' <summary>
        ''' Handles the ClientClick event of the leftButton control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub objLeftButton_ClientClick(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles objLeftButton.ClientClick
            'Calling js callback function to set label's Dock property to "Left".
            SetDockStyle(objArgs.Context, DockStyle.Left)
        End Sub

        ''' <summary>
        ''' Handles the ClientClick event of the topButton control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub objTopButton_ClientClick(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles objTopButton.ClientClick
            'Calling js callback function to set label's Dock property to "Top".
            SetDockStyle(objArgs.Context, DockStyle.Top)
        End Sub

        ''' <summary>
        ''' Handles the ClientClick event of the bottomButton control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub objBottomButton_ClientClick(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles objBottomButton.ClientClick
            'Calling js callback function to set label's Dock property to "Bottom".
            SetDockStyle(objArgs.Context, DockStyle.Bottom)
        End Sub

        ''' <summary>
        ''' Handles the ClientClick event of the rightButton control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub objRightButton_ClientClick(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles objRightButton.ClientClick
            'Calling js callback function to set label's Dock property to "Right".
            SetDockStyle(objArgs.Context, DockStyle.Right)
        End Sub

        ''' <summary>
        ''' Handles the ClientClick event of the fillButton control.
        ''' </summary>
        ''' <param name="objSender">The source of the event.</param>
        ''' <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.Client.ClientEventArgs"/> instance containing the event data.</param>
        Private Sub objFillButton_ClientClick(objSender As System.Object, objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Handles objFillButton.ClientClick
            'Calling js callback function to set label's Dock property to "Fill".
            SetDockStyle(objArgs.Context, DockStyle.Fill)
        End Sub

	End Class

End Namespace