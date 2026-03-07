Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common
Imports Gizmox.WebGUI.Forms.Client

Namespace ComponentOneSampleAppsVB

    Public Class C1GridViewForm

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()

            'Set default theme for wrapper
            mobjWrapper.Theme = "aristo"
            'Define default values
            setNewLabelText()
            mobjNUD.Value = 10
            mobjWrapper.PageSize = 10
        End Sub


        ''' <summary>
        ''' Handles the PageIndexChanged event of the mobjGridViewWrapper control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjGridViewWrapper_PageIndexChanged(sender As Object, e As EventArgs) Handles mobjWrapper.PageIndexChanged
            'Set new Label Text
            setNewLabelText()
        End Sub

        ''' <summary>
        ''' Handles the ValueChanged event of the mobjNUD control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjNUD_ValueChanged(sender As Object, e As EventArgs) Handles mobjNUD.ValueChanged
            'Set new PageSize property value
            mobjWrapper.PageSize = CInt(mobjNUD.Value)
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjShowFilterRow control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjShowFilterRow_CheckedChanged(sender As Object, e As EventArgs) Handles mobjShowFilterRow.CheckedChanged
            'Set new ShowFilter property value
            mobjWrapper.ShowFilter = mobjShowFilterRow.Checked
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjAllowPaging control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjAllowPaging_CheckedChanged(sender As Object, e As EventArgs) Handles mobjAllowPaging.CheckedChanged
            'Set new AllowPaging property value
            mobjWrapper.AllowPaging = mobjAllowPaging.Checked
            'Disable NumericUpDown if needed
            mobjNUD.Enabled = mobjAllowPaging.Checked
            'Set new Label Text
            If Not mobjAllowPaging.Checked Then
                mobjSelectedPageIndex.Text = "Selected Page Index: 0"
            Else
                setNewLabelText()
            End If
        End Sub

        ' ''' <summary>
        ' ''' Handles the Load event of the Page
        ' ''' </summary>
        ' ''' <param name="sender">The source of the event.</param>
        ' ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        'Private Sub Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '    'Define default values
        '    setNewLabelText()
        '    mobjNUD.Value = Convert.ToDecimal(mobjWrapper.PageSize)
        '    MessageBox.Show("it's " + Convert.ToDecimal(mobjWrapper.PageSize).ToString())
        'End Sub

        ''' <summary>
        ''' Handles the Sorted event of the mobjGridViewWrapper control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjGridViewWrapper_Sorted(sender As Object, e As EventArgs) Handles mobjWrapper.Sorted, mobjWrapper.Filtered
            'Set Label Text to a correct value after sorting
            setNewLabelText()
        End Sub

        ''' <summary>
        ''' Sets the new label text.
        ''' </summary>
        Private Sub setNewLabelText()
            mobjSelectedPageIndex.Text = "Selected Page Index: " + mobjWrapper.PageIndex.ToString()
        End Sub

    End Class

End Namespace