Imports ZedGraph

Namespace CompanionKit.Controls.ZedGraph.Functionality

    Public Class GraphDemoPage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()



        End Sub

        ''' <summary>
        ''' Handles the Load event of the GraphDemoPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub GraphDemoPage_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            'Define Graph Pane
            Dim mobjPane As GraphPane = mobjZedGraph.GraphPane

            'Set the Titles
            mobjPane.Title.Text = "Test Graph" & vbLf & "(simple line and bar chart)"
            mobjPane.XAxis.Title.Text = "X Axis"
            mobjPane.YAxis.Title.Text = "Y Axis"

            'Make up some data arrays based on the Sin function
            Dim x As Double, y1 As Double, y2 As Double

            Dim objList1 As New PointPairList()
            Dim objList2 As New PointPairList()
            For i As Integer = 0 To 35
                x = CDbl(i) + 5
                y1 = 1.5 + Math.Sin(CDbl(i) * 0.2)
                y2 = 3.0 * (1.5 + Math.Sin(CDbl(i) * 0.2))
                objList1.Add(x, y1)
                objList2.Add(x, y2)
            Next

            'Generate a red curve with square symbols, and "Porsche" in the legend
            Dim objCurve1 As LineItem = mobjPane.AddCurve("Porsche", objList1, Drawing.Color.Red, SymbolType.Square)

            'Generate a blue curve with circle symbols, and "Piper" in the legend
            Dim objCurve2 As LineItem = mobjPane.AddCurve("Piper", objList2, Drawing.Color.Blue, SymbolType.Circle)

            'Make up some random data points
            Dim yArray As Double() = {10, 15, 7.5, 2.2}
            Dim y2Array As Double() = {9, 10, 9.5, 3.5}
            Dim y3Array As Double() = {8, 11, 6.5, 1.5}
            Dim xArray As Double() = {10, 20, 30, 40}

            'Add bars
            ' Generate a red bar with "Bar 1" in the legend
            Dim myBar As BarItem = mobjPane.AddBar("Bar 1", xArray, yArray, Drawing.Color.Beige)
            myBar.Bar.Fill = New Fill(Drawing.Color.Beige)

            ' Generate a blue bar with "Bar 2" in the legend
            myBar = mobjPane.AddBar("Bar 2", xArray, y2Array, Drawing.Color.LightPink)
            myBar.Bar.Fill = New Fill(Drawing.Color.LightPink)

            ' Generate a green bar with "Bar 3" in the legend
            myBar = mobjPane.AddBar("Bar 3", xArray, y3Array, Drawing.Color.Lavender)
            myBar.Bar.Fill = New Fill(Drawing.Color.Lavender)

            'Refigure the axes since the data have changed
            mobjZedGraph.AxisChange()

            'Add a caption to graph
            Dim objCaption As [String] = "This is a graph caption"
            Dim objText As New TextObj(objCaption, 0.3F, 0.3F)
            objText.FontSpec.Angle = 25.0F
            objText.FontSpec.FontColor = Drawing.Color.Black
            objText.FontSpec.IsBold = True
            objText.FontSpec.Size = 20

            'Disable the border and background fill options for the text
            objText.FontSpec.Border.IsVisible = False
            objText.FontSpec.Fill.IsVisible = False

            'Align the text such the the Left-Bottom corner is at the specified coordinates
            objText.Location.AlignH = AlignH.Left
            objText.Location.AlignV = AlignV.Bottom

            mobjZedGraph.GraphPane.GraphObjList.Add(objText)
            mobjZedGraph.Update()

        End Sub
    End Class

End Namespace