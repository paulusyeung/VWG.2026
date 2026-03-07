Namespace CompanionKit.Controls.ExpandableGroupBox

	Public Class ExpandCollapsePage

		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

	        

		End Sub

        ''' <summary>
        ''' Handles the Collapse event of the mobjExpandableGroupBox1 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjExpandableGroupBox1_Collapse(sender As System.Object, e As System.EventArgs) Handles mobjExpandableGroupBox1.Collapse
            'If no one ExpandableGroupBox is expanded
            If (Not mobjExpandableGroupBox2.IsExpanded) AndAlso (Not mobjExpandableGroupBox3.IsExpanded) Then
                mobjExpColInfo.Text = "Expanded: - "
            End If
        End Sub

        ''' <summary>
        ''' Handles the Expand event of the mobjExpandableGroupBox1 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjExpandableGroupBox1_Expand(sender As System.Object, e As System.EventArgs) Handles mobjExpandableGroupBox1.Expand
            'Make only ExpandableGroupBox1 expanded
            mobjExpandableGroupBox2.IsExpanded = False
            mobjExpandableGroupBox3.IsExpanded = False
            mobjExpColInfo.Text = "Expanded: ExpandableGroupBox1"
        End Sub

        ''' <summary>
        ''' Handles the Collapse event of the mobjExpandableGroupBox2 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjExpandableGroupBox2_Collapse(sender As System.Object, e As System.EventArgs) Handles mobjExpandableGroupBox2.Collapse
            'If no one ExpandableGroupBox is expanded
            If (Not mobjExpandableGroupBox1.IsExpanded) AndAlso (Not mobjExpandableGroupBox3.IsExpanded) Then
                mobjExpColInfo.Text = "Expanded: - "
            End If
        End Sub

        ''' <summary>
        ''' Handles the Expand event of the mobjExpandableGroupBox2 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjExpandableGroupBox2_Expand(sender As System.Object, e As System.EventArgs) Handles mobjExpandableGroupBox2.Expand
            'Make only ExpandableGroupBox2 expanded
            mobjExpandableGroupBox1.IsExpanded = False
            mobjExpandableGroupBox3.IsExpanded = False
            mobjExpColInfo.Text = "Expanded: ExpandableGroupBox2"
        End Sub

        ''' <summary>
        ''' Handles the Collapse event of the mobjExpandableGroupBox3 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjExpandableGroupBox3_Collapse(sender As System.Object, e As System.EventArgs) Handles mobjExpandableGroupBox3.Collapse
            'If no one ExpandableGroupBox is expanded
            If (Not mobjExpandableGroupBox2.IsExpanded) AndAlso (Not mobjExpandableGroupBox1.IsExpanded) Then
                mobjExpColInfo.Text = "Expanded: - "
            End If
        End Sub

        ''' <summary>
        ''' Handles the Expand event of the mobjExpandableGroupBox3 control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub mobjExpandableGroupBox3_Expand(sender As System.Object, e As System.EventArgs) Handles mobjExpandableGroupBox3.Expand
            'Make only ExpandableGroupBox3 expanded
            mobjExpandableGroupBox2.IsExpanded = False
            mobjExpandableGroupBox1.IsExpanded = False
            mobjExpColInfo.Text = "Expanded: ExpandableGroupBox3"
        End Sub
    End Class

End Namespace