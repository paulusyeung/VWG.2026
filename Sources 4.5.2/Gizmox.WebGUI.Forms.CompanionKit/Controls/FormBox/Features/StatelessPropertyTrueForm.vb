Imports Gizmox.WebGUI.Forms
Imports Gizmox.WebGUI.Common

Namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Features

    Public Class StatelessPropertyTrueForm

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
            ' Fill ComboBox with DayOfWeek enumerator values
            cmbDaysOfWeek.DataSource = System.Enum.GetValues(GetType(DayOfWeek))

        End Sub

        ''' <summary>
        ''' Handles Click event of Button control
        ''' </summary>
        Private Sub btnSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSet.Click
            '' Set selected value of ComboBox as a text for a Label
            lblDayofWeek.Text = cmbDaysOfWeek.SelectedValue.ToString()
        End Sub

    End Class

End Namespace

