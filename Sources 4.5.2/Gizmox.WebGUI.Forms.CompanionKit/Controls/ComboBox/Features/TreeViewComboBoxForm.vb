Public Class TreeViewComboBoxForm

    Public Sub New()
        Me.InitializeComponent()
        Me.mobjTreeView.CollapseAll()
    End Sub


    ' Properties
    ''' <summary>
    ''' Gets the tree.
    ''' </summary>
    ''' <value>The tree.</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Tree() As TreeView
        Get
            Return Me.mobjTreeView
        End Get
    End Property


    Private Sub mobjTreeView_AfterSelect(ByVal sender As System.Object, ByVal e As Gizmox.WebGUI.Forms.TreeViewEventArgs) Handles mobjTreeView.AfterSelect
        'Sets successful results for form.
        MyBase.DialogResult = DialogResult.OK
        'Close form.
        MyBase.Close()
    End Sub
End Class
