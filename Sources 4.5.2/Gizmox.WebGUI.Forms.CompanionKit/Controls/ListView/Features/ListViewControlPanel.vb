Partial Public Class ListViewControlPanel
    Inherits UserControl
    Private mstrPrevFrom As String = ""
    Private mstrPrevSubject As String = ""
    Private mblnPrevImportant As Boolean = False
    Private mblnPrevRead As Boolean = False
    Private mblnPrevAttachemnts As Boolean = False
    Private mstrPrevMailSize As String = ""

    Public Sub New()
        InitializeComponent()
    End Sub

    Friend ReadOnly Property IsPanelDirty() As Boolean
        Get
            Return mblnPrevAttachemnts <> Attachemnts OrElse mstrPrevSubject <> Subject OrElse mstrPrevFrom <> From OrElse mstrPrevMailSize <> MailSize OrElse mblnPrevImportant <> Important OrElse mblnPrevRead <> Read
        End Get
    End Property

    Friend Sub SetPrevValues()
        mblnPrevAttachemnts = Attachemnts
        mstrPrevSubject = Subject
        mstrPrevFrom = From
        mstrPrevMailSize = MailSize
        mblnPrevImportant = Important
        mblnPrevRead = Read
    End Sub

    Friend Property Subject() As String
        Get
            Return textBoxSubject.Text
        End Get
        Set(ByVal value As String)
            textBoxSubject.Text = value
        End Set
    End Property

    Friend Property From() As String
        Get
            Return textBoxFrom.Text
        End Get
        Set(ByVal value As String)
            textBoxFrom.Text = value
        End Set
    End Property

    Friend Property MailSize() As String
        Get
            Return textBoxSize.Text
        End Get
        Set(ByVal value As String)
            textBoxSize.Text = value
        End Set
    End Property

    Friend Property Attachemnts() As Boolean
        Get
            Return checkBoxAttachments.Checked
        End Get
        Set(ByVal value As Boolean)
            checkBoxAttachments.Checked = value
        End Set
    End Property

    Friend Property Important() As Boolean
        Get
            Return checkBoxImportant.Checked
        End Get
        Set(ByVal value As Boolean)
            checkBoxImportant.Checked = value
        End Set
    End Property

    Friend Property Read() As Boolean
        Get
            Return checkBoxRead.Checked
        End Get
        Set(ByVal value As Boolean)
            checkBoxRead.Checked = value
        End Set
    End Property
End Class
