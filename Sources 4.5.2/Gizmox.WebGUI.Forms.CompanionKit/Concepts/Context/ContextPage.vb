Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text

Imports Gizmox.WebGUI.Common
Imports Gizmox.WebGUI.Forms
Imports Microsoft.Reporting.WebForms
Imports Gizmox.WebGUI.Common.Interfaces

Namespace CompanionKit.Concepts.Context

    Public Class ContextPage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

            LoadContextParams()
            LoadSessionParams()
            LoadApplicationParams()
            LoadCookiesParams()

        End Sub


        ''' <summary>
        ''' Handles the Click event of the mobjButtonSave1 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjButtonSave1_Click(sender As Object, e As System.EventArgs) Handles mobjButtonSave1.Click
            Me.Context("ParameterA") = Me.mobjParameterATxt1.Text
            Me.Context("ParameterB") = Me.mobjParameterBTxt1.Text
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjButtonLoad1 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjButtonLoad1_Click(sender As Object, e As System.EventArgs) Handles mobjButtonLoad1.Click
            LoadContextParams()
        End Sub

        ''' <summary>
        ''' Loads the context params.
        ''' </summary>
        Private Sub LoadContextParams()
            Me.mobjParameterATxt1.Text = GetContextParameter("ParameterA")
            Me.mobjParameterBTxt1.Text = GetContextParameter("ParameterB")
        End Sub

        ''' <summary>
        ''' Loads the session params.
        ''' </summary>
        Private Sub LoadSessionParams()
            Me.mobjParameterATxt3.Text = GetSessionParameter("ParameterA")
            Me.mobjParameterBTxt3.Text = GetSessionParameter("ParameterB")
        End Sub

        ''' <summary>
        ''' Loads the application params.
        ''' </summary>
        Private Sub LoadApplicationParams()
            Me.mobjParameterATxt4.Text = GetApplicationParameter("ParameterA")
            Me.mobjParameterBTxt4.Text = GetApplicationParameter("ParameterB")
        End Sub

        ''' <summary>
        ''' Loads the cookies params.
        ''' </summary>
        Private Sub LoadCookiesParams()
            Me.mobjParameterATxt2.Text = GetCookiesParameter("ParameterA")
            Me.mobjParameterBTxt2.Text = GetCookiesParameter("ParameterB")
        End Sub

        ''' <summary>
        ''' Gets the context parameter.
        ''' </summary>
        ''' <param name="strKey">The STR key.</param>
        ''' <returns></returns>
        Private Function GetContextParameter(strKey As String) As String
            Dim objValue As Object = VWGContext.Current(strKey)
            If objValue IsNot Nothing Then
                Return objValue.ToString()
            Else
                Return ""
            End If
        End Function

        ''' <summary>
        ''' Gets the session parameter.
        ''' </summary>
        ''' <param name="strKey">The STR key.</param>
        ''' <returns></returns>
        Private Function GetSessionParameter(strKey As String) As String
            Dim objValue As Object = VWGContext.Current.Session(strKey)
            If objValue IsNot Nothing Then
                Return objValue.ToString()
            Else
                Return ""
            End If
        End Function

        ''' <summary>
        ''' Gets the cookies parameter.
        ''' </summary>
        ''' <param name="strKey">The STR key.</param>
        ''' <returns></returns>
        Private Function GetCookiesParameter(strKey As String) As String
            Dim objValue As Object = VWGContext.Current.Cookies(strKey)
            If objValue IsNot Nothing Then
                Return objValue.ToString()
            Else
                Return ""
            End If
        End Function

        ''' <summary>
        ''' Gets the application parameter.
        ''' </summary>
        ''' <param name="strKey">The STR key.</param>
        ''' <returns></returns>
        Private Function GetApplicationParameter(strKey As String) As String
            Dim objValue As Object = VWGContext.Current.Application(strKey)
            If objValue IsNot Nothing Then
                Return objValue.ToString()
            Else
                Return ""
            End If
        End Function

        ''' <summary>
        ''' Handles the Click event of the mobjButtonSave3 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjButtonSave3_Click(sender As Object, e As System.EventArgs) Handles mobjButtonSave3.Click
            SyncLock mobjLock
                VWGContext.Current.Session("ParameterA") = Me.mobjParameterATxt3.Text
                VWGContext.Current.Session("ParameterB") = Me.mobjParameterBTxt3.Text
            End SyncLock
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjButtonSave4 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjButtonSave4_Click(sender As Object, e As System.EventArgs) Handles mobjButtonSave4.Click
            SyncLock mobjLock
                VWGContext.Current.Application("ParameterA") = Me.mobjParameterATxt4.Text
                VWGContext.Current.Application("ParameterB") = Me.mobjParameterBTxt4.Text
            End SyncLock
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjButtonLoad3 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjButtonLoad3_Click(sender As Object, e As System.EventArgs) Handles mobjButtonLoad3.Click
            LoadSessionParams()
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjButtonLoad4 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjButtonLoad4_Click(sender As Object, e As System.EventArgs) Handles mobjButtonLoad4.Click
            LoadApplicationParams()
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjButtonLoad2 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjButtonLoad2_Click(sender As Object, e As System.EventArgs) Handles mobjButtonLoad2.Click
            LoadCookiesParams()
        End Sub

        ''' <summary>
        ''' Handles the Click event of the mobjButtonSave2 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjButtonSave2_Click(sender As Object, e As System.EventArgs) Handles mobjButtonSave2.Click
            VWGContext.Current.Cookies("ParameterA") = Me.mobjParameterATxt2.Text
            VWGContext.Current.Cookies("ParameterB") = Me.mobjParameterBTxt2.Text
        End Sub
    End Class
End Namespace
