Imports System.Web
Imports System.Environment
Imports Gizmox.WebGUI.Common
Imports Gizmox.WebGUI.Common.Resources
Imports Gizmox.WebGUI.Common.Gateways
Imports Gizmox.WebGUI.Common.Interfaces

Namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.ApplicationScenarios

	Public Class DisplayPicturePage

		' Fields
		''' <summary>
		''' Represents full name of user selected file
		''' </summary>
		''' <remarks></remarks>
		Private _selectedFile As String

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

		End Sub


        Private Sub DisplayPicturePage_Load(sender As Object, e As EventArgs) Handles Me.Load
            'Set initial image for PictureBox
            Me.mobjRepresentedPictureBox.BackgroundImage = New ImageResourceHandle("View.jpg")
            Me.mobjRepresentedPictureBox.BackgroundImageLayout = ImageLayout.Stretch
        End Sub

        Private Sub mobjOpenFileButton_Click(sender As Object, e As EventArgs) Handles mobjOpenFileButton.Click
            'Set images file Filter for Open File Dialog .
            Me.mobjDemoOpenFileDialog.Filter = "Image Files (JPEG,GIF,BMP)|*.jpg;*.jpeg;*.gif;*.bmp|JPEG Files(*.jpg;*.jpeg)|*.jpg;*.jpeg|GIF Files(*.gif)|*.gif|BMP Files(*.bmp)|*.bmp"
            'Show OpenFile Dialog
            Me.mobjDemoOpenFileDialog.ShowDialog()
        End Sub

        Private Sub mobjDemoOpenFileDialog_Closed(sender As Object, e As EventArgs) Handles mobjDemoOpenFileDialog.Closed
            'Load image file in PictureBox if user click on OK Button
            If Me.mobjDemoOpenFileDialog.DialogResult = DialogResult.OK Then
                'Set full name of selected file
                _selectedFile = Me.mobjDemoOpenFileDialog.File.FileName
                'Set ResourceHandle with selected image file for Picturebox Image.
                Me.mobjRepresentedPictureBox.BackgroundImage = New GatewayResourceHandle(New GatewayReference(Me, "image"))
                Me.mobjRepresentedPictureBox.Update()
            End If
        End Sub

        Protected Overrides Function ProcessGatewayRequest(ByVal objHttpContext As HttpContext, ByVal strAction As String) As IGatewayHandler
            If ((Not strAction Is Nothing) AndAlso (strAction = "image")) Then
                Return New FileHandler(Me._selectedFile)
            End If
            Return MyBase.ProcessGatewayRequest(objHttpContext, strAction)
        End Function



		''' <summary>
		''' Summary description for FileHandler.
		''' </summary>
		Public Class FileHandler
			Implements IGatewayHandler
			' Methods
			Public Sub New(ByVal fileName As String)
				Me._fileName = fileName
			End Sub

			Public Sub ProcessGatewayRequest(ByVal objContext As IContext, ByVal objComponent As IRegisteredComponent) Implements IGatewayHandler.ProcessGatewayRequest
				HttpContext.Current.Response.WriteFile(Me._fileName)
			End Sub

			' Fields
			Private _fileName As String
		End Class

	End Class

End Namespace