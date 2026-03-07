Namespace CompanionKit.Controls.ObjectBox.Programming

	Public Class ProvideParametersPage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        ''' <summary>
        ''' Handles the Load event of the ProvideParametersPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub ProvideParametersPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Dim demoObjectBox As New CustomObjectBox
            demoObjectBox.Anchor = AnchorStyles.None
            demoObjectBox.Dock = DockStyle.Fill
            demoObjectBox.Location = New Drawing.Point(0, 0)
            demoObjectBox.Name = "demoActiveXBox"
            demoObjectBox.Movie = "../../../../../../Resources/Flash/FC_2_3_Area2D.swf"
            demoObjectBox.Parameters.Add("FlashVars", "&dataURL=../../../../../../Resources/Flash/FC_2_3_DATA.xml")
            demoObjectBox.Parameters.Add("quality", "high")
            demoObjectBox.Size = New Drawing.Size(&H187, 450)
            demoObjectBox.TabIndex = 0

            MyBase.Controls.Add(demoObjectBox)

        End Sub

        ''' <summary>
        ''' This class is used display flash animation.
        ''' </summary>
        Private Class CustomObjectBox
            Inherits Gizmox.WebGUI.Forms.Hosts.ObjectBox

            Public Sub New()
                MyBase.ObjectClassId = "clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"
                MyBase.ObjectCodeBase = "http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0"
                MyBase.ObjectPluginsPageType = "http://www.macromedia.com/go/getflashplayer"
                MyBase.ObjectType = "application/x-shockwave-flash"
            End Sub


            ''' <summary>
            ''' Gets or sets Class Id for object box
            ''' </summary>
            Public Property ClassId() As String
                Get
                    Return MyBase.ObjectClassId
                End Get
                Set(ByVal value As String)
                    MyBase.ObjectClassId = value
                End Set
            End Property

            ''' <summary>
            ''' Gets or sets Code Base for object box
            ''' </summary>
            Public Property CodeBase() As String
                Get
                    Return MyBase.ObjectCodeBase
                End Get
                Set(ByVal value As String)
                    MyBase.ObjectCodeBase = value
                End Set
            End Property

            ''' <summary>
            ''' Gets or sets Type for object box
            ''' </summary>
            Public Property Type() As String
                Get
                    Return MyBase.ObjectType
                End Get
                Set(ByVal value As String)
                    MyBase.ObjectType = value
                End Set
            End Property

            Public Property Movie() As String
                Get
                    If MyBase.Parameters.Contains("src") Then
                        Return MyBase.Parameters.Item("src").ToString
                    End If
                    Return String.Empty
                End Get
                Set(ByVal value As String)
                    MyBase.Parameters.Item("src") = value
                End Set
            End Property

        End Class

	End Class

End Namespace
