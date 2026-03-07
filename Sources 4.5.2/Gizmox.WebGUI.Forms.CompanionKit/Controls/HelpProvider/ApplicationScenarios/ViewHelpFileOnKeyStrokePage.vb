Namespace CompanionKit.Controls.HelpProvider.ApplicationScenarios

    Public Class ViewHelpFileOnKeyStrokePage

        ' Create an instance of Config class that contains 
        ' settings from web.config file
        Private Shared mobjConfig As WebGUI.Common.Configuration.Config

        ''' <summary>
        ''' Contains path to help file
        ''' </summary>
        Private Shared ReadOnly Property ProjectCHM() As String
            Get
                Return System.IO.Path.Combine(ViewHelpFileOnKeyStrokePage.mobjConfig.GetDirectory("Data"), "Help.chm")
            End Get
        End Property

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles Load event for Page
        ''' </summary>
        Private Sub ViewHelpFileOnKeyStrokePage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Set help keywords for controls
            Me.mobjHelpProvider.SetHelpKeyword(Me.mobjTextBox, "TextBox class")
            Me.mobjHelpProvider.SetHelpKeyword(Me.mobjComboBox, "ComboBox class")
            Me.mobjHelpProvider.SetHelpKeyword(Me.mobjListBox, "ListBox class")
            Me.mobjHelpProvider.SetHelpKeyword(Me.mobjDomainUpDown, "DomainUpDown class")
            Me.mobjHelpProvider.SetHelpKeyword(Me.mobjNumericUpDown, "NumericUpDown class")
            Me.mobjHelpProvider.SetHelpKeyword(Me.mobjLinkLabel, "LinkLabel class")
            Me.mobjHelpProvider.SetHelpKeyword(Me.mobjRadioButton1, "RadioButton class")
            Me.mobjHelpProvider.SetHelpKeyword(Me.mobjRadioButton2, "RadioButton class")
            Me.mobjHelpProvider.SetHelpKeyword(Me.mobjCheckBox, "CheckBox class")
            ' Set KeyDown event handler for controls
            AddHandler Me.mobjTextBox.KeyDown, New KeyEventHandler(AddressOf Me.Control_KeyDown)
            AddHandler Me.mobjComboBox.KeyDown, New KeyEventHandler(AddressOf Me.Control_KeyDown)
            AddHandler Me.mobjListBox.KeyDown, New KeyEventHandler(AddressOf Me.Control_KeyDown)
            AddHandler Me.mobjDomainUpDown.KeyDown, New KeyEventHandler(AddressOf Me.Control_KeyDown)
            AddHandler Me.mobjNumericUpDown.KeyDown, New KeyEventHandler(AddressOf Me.Control_KeyDown)
            AddHandler Me.mobjLinkLabel.KeyDown, New KeyEventHandler(AddressOf Me.Control_KeyDown)
            AddHandler Me.mobjRadioButton1.KeyDown, New KeyEventHandler(AddressOf Me.Control_KeyDown)
            AddHandler Me.mobjRadioButton2.KeyDown, New KeyEventHandler(AddressOf Me.Control_KeyDown)
            AddHandler Me.mobjCheckBox.KeyDown, New KeyEventHandler(AddressOf Me.Control_KeyDown)
        End Sub

        ''' <summary>
        ''' Handles KeyDown event for control
        ''' </summary>
        Private Sub Control_KeyDown(ByVal objSender As System.Object, ByVal objArgs As Gizmox.WebGUI.Forms.KeyEventArgs)
            ' If F1 key pressed
            If objArgs.KeyCode = Keys.F1 Then
                ' Show help file
                Help.ShowHelp(Me, ProjectCHM, HelpNavigator.KeywordIndex, mobjHelpProvider.GetHelpKeyword(DirectCast(objSender, Control)))
            End If
        End Sub

    End Class

End Namespace