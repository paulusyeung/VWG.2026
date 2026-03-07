' Written by Ryan D. Hatch on 2008.04.22
Imports Gizmox.WebGUI.Common
Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common.Interfaces
Imports System.Web
Imports System.IO
Imports Gizmox.WebGUI.Common.Gateways

Namespace CompanionKit.Controls.DataGridView.Features

    ''' <summary>
    ''' Usage:
    ''' Dim myDownload As New FileDownloadGateway()
    ''' myDownload.Filename = "myDocument.doc"
    ''' myDownload.SetContentType(ContentType.OctetStream)
    '''
    ''' myDownload.StartFileDownload(Me, "C:\File.doc")
    ''' OR USE:
    ''' Dim myStream As New FileStream("C:\File.doc", FileMode.Open)
    ''' myStream.Position = 0
    ''' myDownload.StartStreamDownload(Me, myStream)
    ''' </summary>
    ''' <remarks></remarks>

    <MetadataTag("CompanionKit.Controls.DataGridView.Features.FileDownloadGateway")> _
    Public Class FileDownloadGateway
        Inherits Gizmox.WebGUI.Forms.Control

        Private ContentType As String
        Private myContainer As ContainerControl
        Private myStream As Stream
        Private myFilePath As String

        Public Filename As String
        Public LinkParameters As New LinkParameters
        Public DownloadAsAttachment As Boolean = True
        Private _myString As String


        Public Sub New()
            'Default Link Parameters
            LinkParameters.Target = "_self"
        End Sub

        Public Sub SetContentType(ByVal argContentType As DownloadContentType)
            Me.ContentType = Me.getContentType(argContentType)
        End Sub

        Public Sub SetContentType(ByVal argContentType As String)
            Me.ContentType = argContentType
        End Sub

        Public Sub StartFileDownload(ByRef argContainerFormOrUserControl As ContainerControl, ByVal argFilePath As String)
            myStream = Nothing
            myFilePath = argFilePath
            Me._myString = Nothing

            StartDownload(argContainerFormOrUserControl)
        End Sub

        Public Sub StartStreamDownload(ByRef argContainerFormOrUserControl As ContainerControl, ByRef argStream As Stream)
            myStream = argStream
            myFilePath = Nothing
            Me._myString = Nothing
            StartDownload(argContainerFormOrUserControl)
        End Sub

        Public Sub StartStringDownload(ByVal argContainerFormOrUserControl As ContainerControl, ByVal argString As String)
            Me.myStream = Nothing
            Me.myFilePath = Nothing
            Me._myString = argString
            Me.StartDownload(argContainerFormOrUserControl)
        End Sub


        Private Sub StartDownload(ByRef argContainer As ContainerControl)
            'Set Parent Container
            myContainer = argContainer

            'Add Myself to Container (to get current HTTP Context)
            myContainer.Controls.Add(Me)

            'Open Link to ourself as a Gateway (using empty Action string) -> Calls Me.GetGatewayHandler()
            Link.Open(New GatewayReference(Me, "empty"), LinkParameters)

        End Sub

        ''' <summary>
        ''' This is the core Function that writes to the HTTP Response Stream
        ''' </summary>
        Protected Overrides Function ProcessGatewayRequest(ByVal objContext As HttpContext, ByVal strAction As String) As IGatewayHandler
            'Get HTTP Response Object
            Dim objResponse As HttpResponse = objContext.Response

            'Set the Content-Type
            If Me.ContentType IsNot Nothing Then
                objResponse.ContentType = ContentType
            End If

            'Set Filename Header
            If Me.DownloadAsAttachment = True And Me.Filename IsNot Nothing Then
                'add the response headers
                objResponse.AddHeader("content-disposition", "attachment; filename=""" & Me.Filename & """")
            End If

            ''Send File out to HTTP Stream
            'If myStream Is Nothing Then
            '    'Write to Stream using using FileStream
            '    objResponse.WriteFile(myFilePath)
            'Else
            '    'Write to Stream using Byte Array
            '    Dim myByteArray As Byte() = GetStreamAsByteArray(myStream)
            '    objResponse.BinaryWrite(myByteArray)
            'End If

            'Send File out to HTTP Stream
            If (Not Me.myFilePath Is Nothing) Then
                'Write to Stream using using FileStream
                objResponse.WriteFile(Me.myFilePath)
            ElseIf (Not Me._myString Is Nothing) Then
                'Write to Stream using string
                objResponse.Write(Me._myString)
            Else
                'Write to Stream using Byte Array
                Dim myByteArray As Byte() = Me.GetStreamAsByteArray(Me.myStream)
                objResponse.BinaryWrite(myByteArray)
            End If

            'Close the HTTP Response Stream
            objResponse.End()

            'Remove Myself from Container
            myContainer.Controls.Remove(Me)

            Return Nothing

        End Function

        Private Function getContentType(ByVal myContentType As DownloadContentType) As String
            Select Case myContentType
                Case DownloadContentType.OctetStream
                    Return "application/octet-stream"
                Case DownloadContentType.MicrosoftWord
                    Return "application/x-msword"
                Case DownloadContentType.MicrosoftExcel
                    Return "application/x-msexcel"
                Case DownloadContentType.PlainText Or Nothing
                    Return "text/plain"
            End Select
            Return Nothing
        End Function

        Private Function GetStreamAsByteArray(ByRef stream As System.IO.Stream) As Byte()

            Dim streamLength As Integer = Convert.ToInt32(stream.Length)

            Dim fileData As Byte() = New Byte(streamLength) {}

            ' Read the file into a byte array

            stream.Read(fileData, 0, streamLength)

            stream.Close()

            Return fileData

        End Function

#Region "UserControl"
        'Object Needs to be a VWG Control to get IRegisteredComponent

        'Overrides dispose to clean up the component list.
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
            components = New System.ComponentModel.Container()
        End Sub

#End Region

    End Class

    Public Enum DownloadContentType
        OctetStream
        MicrosoftExcel
        MicrosoftWord
        PlainText
    End Enum

End Namespace
