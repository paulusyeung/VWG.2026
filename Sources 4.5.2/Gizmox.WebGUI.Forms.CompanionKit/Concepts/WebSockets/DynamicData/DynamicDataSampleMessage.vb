Namespace WebSocketsSampleAppsVB
    Public Class DynamicDataSampleMessage
        Inherits CompanionKitWebSocketMessage
        ''' <summary>
        ''' Gets or sets the random values.
        ''' </summary>
        ''' <value>
        ''' The random values.
        ''' </value>
        Public Property RandomValues() As Integer()
            Get
                Return m_RandomValues
            End Get
            Set(ByVal value As Integer())
                m_RandomValues = value
            End Set
        End Property
        Private m_RandomValues As Integer()

        Public Sub New()
            Me.RandomValues = New Integer(4) {}
        End Sub
    End Class
End Namespace