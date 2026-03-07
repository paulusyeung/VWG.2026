Namespace CompanionKit.Controls.DataGridView.PopulatingData

    Public Class HierarchiesPage

        Public Sub New()

            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()



        End Sub

        ''' <summary>
        ''' Handles the Load event of the HierarchiesPage control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub HierarchiesPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Fill DataGridView
            Me.ordersAdapter.Fill(mobjDS.Orders)
            Me.orderDetailsAdapter.Fill(Me.mobjDS.Order_Details)
            Me.productsAdapter.Fill(Me.mobjDS.Products)
        End Sub
    End Class

End Namespace