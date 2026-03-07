Imports System.Globalization
Namespace CompanionKit.Controls.DateTimePicker.Features

    Public Class LangaugesPage

        Private _currentUICulture As CultureInfo


        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles Load event of the example' UserControl.
        ''' </summary>
        Private Sub LangaugesPage_Load(sender As Object, e As EventArgs) Handles Me.Load
            _currentUICulture = Context.CurrentUICulture
            ' Fill up the ConboBox with support languages.
            Me.mobjLanguagesComboBox.DataSource = [Enum].GetValues(GetType(SupportLanguages))

        End Sub

        ''' <summary>
        ''' Handles SelectedIndexChanged event of the ComboBox that contains
        ''' support languages. Sets selected languages for the current page.
        ''' </summary>
        Private Sub mobjLanguagesComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mobjLanguagesComboBox.SelectedIndexChanged
            ' Set selected languages for the current page.
            Dim selectedLanguage As SupportLanguages = CType(Me.mobjLanguagesComboBox.SelectedItem, SupportLanguages)
            Select Case selectedLanguage
                Case SupportLanguages.English
                    Context.CurrentUICulture = New CultureInfo("en-US", False)
                    Exit Select
                Case SupportLanguages.French
                    Context.CurrentUICulture = New CultureInfo("fr-FR", False)
                    Exit Select
                Case SupportLanguages.German
                    Context.CurrentUICulture = New CultureInfo("de-DE", False)
                    Exit Select
                Case SupportLanguages.Hebrew
                    Context.CurrentUICulture = New CultureInfo("he-IL", False)
                    Exit Select
                Case Else
                    Context.CurrentUICulture = New CultureInfo("en-US", False)
                    Exit Select
            End Select

        End Sub
        ''' <summary>
        ''' Represents support languages
        ''' </summary>
        Private Enum SupportLanguages
            English
            French
            German
            Hebrew
        End Enum

        ''' <summary>
        ''' Handles VisibleChanged event of the example' UserControl.
        ''' Sets default globalization settings for the project.
        ''' </summary>
        Private Sub LangaugesPage_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
            If _currentUICulture IsNot Nothing Then
                Context.CurrentUICulture = _currentUICulture
            End If
        End Sub
    End Class

End Namespace