Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common
Imports Newtonsoft.Json

Namespace WebSocketsSampleAppsVB
    Partial Public Class ChatForm
        Inherits Form
        Implements IPageHandler
        Public Sub New()
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles the Load event of the ChatPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub ChatPage_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            'Sets WebSocket's handler class
            Application.WebSockets.SetHandler(Of ChatWebSocketsHandler)()
            'Tries to cast WebSocketHandler as CompanionKitWebSocketsHandler
            Dim objHandler As ChatWebSocketsHandler = TryCast(Application.WebSockets.WebSocketHandler, ChatWebSocketsHandler)
            If objHandler IsNot Nothing Then
                'Sets current instance to Page property
                objHandler.Page = Me
            End If
        End Sub

        ''' <summary>
        ''' Pages the handle.
        ''' </summary>
        ''' <param name="strConnectionId">The STR connection id.</param>
        ''' <param name="strData">The STR data.</param>
        Public Sub PageHandle(ByVal strConnectionId As String, ByVal strData As String) Implements IPageHandler.PageHandle
            'Desearialize string data to ChatSampleMessage object
            Dim mobjMessage As ChatSampleMessage = JsonConvert.DeserializeObject(Of ChatSampleMessage)(strData)
            'If received data truly have ChatSampleMessage type, then proceed...
            If mobjMessage.ObjectType.Equals(mobjMessage.[GetType]()) Then
                Dim strName As String = mobjMessage.Name
                'If it's the client who sent the message
                If strConnectionId = Application.WebSockets.ConnectionId Then
                    strName = "[ME]"
                    'Disable Name watermarkTextBox if it's enabled
                    If mobjNameTextBox.Enabled Then
                        mobjNameTextBox.Enabled = False
                    End If
                End If
                'Displays received message at Chat's textBox
                mobjChatTextBox.Text += String.Format("{0}:{1} " & vbCr & vbLf, strName, mobjMessage.Message)
            End If
        End Sub

        ''' <summary>
        ''' Pages the client handle.
        ''' </summary>
        ''' <param name="objSender">The obj sender.</param>
        ''' <param name="objArgs">The <see cref="ClientEventArgs" /> instance containing the event data.</param>
        Public Sub PageClientHandle(ByVal objSender As Object, ByVal objArgs As Gizmox.WebGUI.Forms.Client.ClientEventArgs) Implements IPageHandler.PageClientHandle
            'Not implemented. Retained for interface compatibility. 
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjSendButton control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjSendButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mobjSendButton.Click

            'If Name watermarkTextBox is empty
            If mobjNameTextBox.Text = "" Then
                MessageBox.Show("Please enter your name!")

                'If message text is not empty
            ElseIf Not String.IsNullOrWhiteSpace(mobjMessageTextBox.Text) Then
                Dim mobjMessage As New ChatSampleMessage(mobjNameTextBox.Text, mobjMessageTextBox.Text)
                'Sends the message to all the clients
                ChatSampleMessage.SendMessage(mobjMessage)
                'Clears the message TextBox and returns focus back
                mobjMessageTextBox.Text = ""
                mobjMessageTextBox.Focus()
            End If
        End Sub
    End Class
End Namespace
