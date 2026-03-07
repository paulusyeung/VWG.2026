Imports ZedGraph

Namespace CompanionKit.Controls.ZedGraph.Functionality

    Public Class PieChartPage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()



        End Sub

        ''' <summary>
        ''' Handles the Load event of the PieChartPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub GraphDemoPage_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            'Define Graph Pane
            Dim mobjPane As GraphPane = mobjZedGraph.GraphPane

            'Set the GraphPane title
            mobjPane.Title.Text = "Graph with Pie Chart"
            mobjPane.Title.FontSpec.Size = 10.0F

            'Set the legend to an arbitrary location
            mobjPane.Legend.Position = LegendPos.Float
            mobjPane.Legend.Location = New Location(0.95F, 0.15F, CoordType.PaneFraction, AlignH.Right, AlignV.Top)
            mobjPane.Legend.FontSpec.Size = 10.0F
            mobjPane.Legend.IsHStack = False

            'Add some pie slices
            Dim segment1 As PieItem = mobjPane.AddPieSlice(20, Drawing.Color.Navy, Drawing.Color.White, 45.0F, 0, "North")
            Dim segment3 As PieItem = mobjPane.AddPieSlice(30, Drawing.Color.Purple, Drawing.Color.White, 45.0F, 0.0, "East")
            Dim segment4 As PieItem = mobjPane.AddPieSlice(10.21, Drawing.Color.LimeGreen, Drawing.Color.White, 45.0F, 0, "West")
            Dim segment2 As PieItem = mobjPane.AddPieSlice(40, Drawing.Color.SandyBrown, Drawing.Color.White, 45.0F, 0.2, "South")
            Dim segment6 As PieItem = mobjPane.AddPieSlice(250, Drawing.Color.Red, Drawing.Color.White, 45.0F, 0, "Europe")
            Dim segment7 As PieItem = mobjPane.AddPieSlice(50, Drawing.Color.Blue, Drawing.Color.White, 45.0F, 0.2, "Pac Rim")
            Dim segment8 As PieItem = mobjPane.AddPieSlice(400, Drawing.Color.Green, Drawing.Color.White, 45.0F, 0, "South America")
            Dim segment9 As PieItem = mobjPane.AddPieSlice(50, Drawing.Color.Yellow, Drawing.Color.White, 45.0F, 0.2, "Africa")

            'Calculate the Axis Scale Ranges
            mobjZedGraph.AxisChange()
        End Sub
    End Class

End Namespace