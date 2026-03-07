Imports System.Drawing

Namespace CompanionKit.Controls.LabelFolder.Features

    Public Class LabelTextAlignPage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Handles the Load event of the LabelTextAlignPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub LabelTextAlignPage_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            ' Set data source for ComboBox controls
            Me.mobjCB1.DataSource = System.Enum.GetValues(GetType(ContentAlignment))
            Me.mobjCB2.DataSource = System.Enum.GetValues(GetType(ContentAlignment))
            Me.mobjCB3.DataSource = System.Enum.GetValues(GetType(ContentAlignment))
            ' Set selected items for ComboBox controls
            Me.mobjCB1.SelectedItem = Me.mobjLabel1.TextAlign
            Me.mobjCB2.SelectedItem = Me.mobjLabel2.TextAlign
            Me.mobjCB3.SelectedItem = Me.mobjLabel3.TextAlign
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the comboBox1 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub comboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mobjCB1.SelectedIndexChanged
            ' Set text alignment for Label control
            Me.mobjLabel1.TextAlign = DirectCast(Me.mobjCB1.SelectedItem, ContentAlignment)
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the comboBox2 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub comboBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mobjCB2.SelectedIndexChanged
            ' Set text alignment for Label control
            Me.mobjLabel2.TextAlign = DirectCast(Me.mobjCB2.SelectedItem, ContentAlignment)
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the comboBox3 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub comboBox3_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mobjCB3.SelectedIndexChanged
            ' Set text alignment for Label control
            Me.mobjLabel3.TextAlign = DirectCast(Me.mobjCB3.SelectedItem, ContentAlignment)
        End Sub

    End Class

End Namespace