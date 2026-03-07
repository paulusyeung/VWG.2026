Imports Gizmox.WebGUI.Forms.Charts

Namespace CompanionKit.Controls.Chart.Features

    Public Class View3DPropertyPage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
            ' Set chart and bind chart data
            InitializeChart()
        End Sub
        ''' <summary>
        ''' Sets the chart and binds chart data
        ''' </summary>
        Private Sub InitializeChart()
            ' Set theme for chart
            Me.mobjChart.Theme = ThemeTypes.Theme1
            ' Create X axis
            Dim x As New AxisX()
            x.Title = "OS Name"
            ' Create Y axis
            Dim y As New AxisY()
            y.Title = "Percent Usage"
            y.Suffix = "%"
            ' Set chart
            Me.mobjChart.Title = New Title("Usage share of operating systems, May 2011")
            Me.mobjChart.AxisX = x
            Me.mobjChart.AxisY = y
            ' Create new data series for chart
            Dim ds As New DataSeries()
            ' Set dataseries
            ds.Name = "Operation Systems"
            ds.RenderAs = DisplayTypes.Column
            ds.LabelEnabled = True
            ' Add points to data series
            ds.Add("Windows XP", 40.26)
            ds.Add("Windows 7", 27.49)
            ds.Add("Windows Vista", 13.95)
            ds.Add("Mac OS X", 7.12)
            ds.Add("iOS", 2.2)
            ds.Add("Linux", 1.82)
            ' Add dataseries to chart data
            Me.mobjChart.Data.Add(ds)
            ' Create new data series for chart
            ds = New DataSeries()
            ' Set dataseries
            ds.Name = "Percent Usage Apr 2011"
            ds.RenderAs = DisplayTypes.Line
            ds.MarkerScale = 0.8
            ds.ToolTipText = "Percent Usage, Apr 2011: #YValue"
            ' Add points to data series
            Dim dp As New DataPoint()
            dp.YValue = 38.37
            ds.Add(dp)

            dp = New DataPoint()
            dp.YValue = 29.19
            ds.Add(dp)

            dp = New DataPoint()
            dp.YValue = 13.27
            ds.Add(dp)

            dp = New DataPoint()
            dp.YValue = 7.54
            ds.Add(dp)

            dp = New DataPoint()
            dp.YValue = 2.8
            ds.Add(dp)

            dp = New DataPoint()
            dp.YValue = 1.1
            ds.Add(dp)
            ' Add dataseries to chart data
            Me.mobjChart.Data.Add(ds)
            ' Update chart
            Me.mobjChart.Update()
        End Sub

        ''' <summary>
        ''' Handles the CheckedChanged event of the mobjView3DCheckBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub mobjView3DCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles mobjView3DCheckBox.CheckedChanged
            ' Swith chart View3D property value
            Me.mobjChart.View3D = Me.mobjView3DCheckBox.Checked
            ' Update chart
            Me.mobjChart.Update()
        End Sub

    End Class

End Namespace