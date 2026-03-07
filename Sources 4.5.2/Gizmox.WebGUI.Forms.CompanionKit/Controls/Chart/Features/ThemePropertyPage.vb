Imports Gizmox.WebGUI.Forms.Charts

Namespace CompanionKit.Controls.Chart.Features

    Public Class ThemePropertyPage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
            ' Set chart and bind chart data
            Me.InitializeChart()
            ' Fill ComboBox items collection with ThemeTypes enum values
            Me.mobjThemesComboBox.DataSource = System.Enum.GetValues(GetType(ThemeTypes))
            ' Set selected item for ComboBox control
            Me.mobjThemesComboBox.SelectedItem = Me.mobjChart.Theme
        End Sub

        ''' <summary>
        ''' Setups the chart and binds chart data
        ''' </summary>
        Private Sub InitializeChart()
            ' Set theme for chart
            Me.mobjChart.Theme = ThemeTypes.Theme1
            ' Create X axis
            Dim x As New AxisX()
            x.Title = "OS Name"
            ' Create Y axis
            Dim y As New AxisY()
            y.Title = "U.S. Smartphone Market Share"
            y.Suffix = "%"
            ' Setup chart
            Me.mobjChart.Title = New Title("U.S. Smartphone Market Share, May 2011")
            Me.mobjChart.AxisX = x
            Me.mobjChart.AxisY = y
            ' Create new data series for chart
            Dim ds As New DataSeries()
            ' Setup dataseries
            ds.Name = "Percent usage"
            ds.RenderAs = DisplayTypes.Pie
            ds.MarkerScale = 0.8
            ds.ToolTipText = "Percent usage: #YValue"
            ' Add points to data series
            ds.Add("Android OS", 36)
            ds.Add("Apple iOS", 26)
            ds.Add("RIM BlackBerry OS", 23)
            ds.Add("Windows Mobile", 9)
            ds.Add("HP WebOS", 2)
            ds.Add("Symbian OS", 2)
            ds.Add("Windows Phone 7", 1)
            ds.Add("Palm OS", 1)
            ' Add dataseries to chart data
            Me.mobjChart.Data.Add(ds)
            ' Update chart
            Me.mobjChart.Update()
        End Sub

        ''' <summary>
        ''' Handles the SelectedIndexChanged event of the mobjThemesComboBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjThemesComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mobjThemesComboBox.SelectedIndexChanged
            ' Set theme for chart from combobox selected item
            Me.mobjChart.Theme = DirectCast(Me.mobjThemesComboBox.SelectedItem, ThemeTypes)
            ' Update chart
            Me.mobjChart.Update()
        End Sub

    End Class

End Namespace