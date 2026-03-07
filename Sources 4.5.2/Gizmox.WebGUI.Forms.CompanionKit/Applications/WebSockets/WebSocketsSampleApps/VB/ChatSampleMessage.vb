Namespace Gizmox.WebGUI.Forms.CompanionKit.WebSocketsSampleAppsVB
    Public Class ChatSampleMessage
        Inherits CompanionKitWebSocketMessage
        ''' <summary>
        ''' Gets or sets the name.
        ''' </summary>
        ''' <value>
        ''' The name.
        ''' </value>
        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(ByVal value As String)
                m_Name = value
            End Set
        End Property
        Private m_Name As String

        ''' <summary>
        ''' Gets or sets the message.
        ''' </summary>
        ''' <value>
        ''' The message.
        ''' </value>
        Public Property Message() As String
            Get
                Return m_Message
            End Get
            Set(ByVal value As String)
                m_Message = value
            End Set
        End Property
        Private m_Message As String

        Public Sub New(ByVal strName As String, ByVal strMessage As String)
            Me.Name = strName
            Me.Message = strMessage
        End Sub
    End Class
End Namespace