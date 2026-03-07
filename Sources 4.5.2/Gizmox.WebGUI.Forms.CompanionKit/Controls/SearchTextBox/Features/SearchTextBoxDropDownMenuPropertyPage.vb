Namespace CompanionKit.Controls.SearchTextBox.Features

	Public Class SearchTextBoxDropDownMenuPropertyPage

        Public Sub New()
            ' This call is required by the Visual WebGui UserControl Designer.
            InitializeComponent()
            ' Create menu items
            Dim item1 As New MenuItem("Top 5 searches")
            Dim item11 As New MenuItem("free movies")
            Dim item12 As New MenuItem("music")
            Dim item13 As New MenuItem("funny cats")
            Dim item14 As New MenuItem("online tv")
            Dim item15 As New MenuItem("video chat")
            ' Add Click event handlers to menu items
            AddHandler item11.Click, New EventHandler(AddressOf Me.menuItem_Click)
            AddHandler item12.Click, New EventHandler(AddressOf Me.menuItem_Click)
            AddHandler item13.Click, New EventHandler(AddressOf Me.menuItem_Click)
            AddHandler item14.Click, New EventHandler(AddressOf Me.menuItem_Click)
            AddHandler item15.Click, New EventHandler(AddressOf Me.menuItem_Click)
            ' Add menu items to context menu
            item1.MenuItems.Add(item11)
            item1.MenuItems.Add(item12)
            item1.MenuItems.Add(item13)
            item1.MenuItems.Add(item14)
            item1.MenuItems.Add(item15)
            Me.contextMenu1.MenuItems.Add(item1)

            ' Create menu items
            Dim item2 As New MenuItem("Search engines")
            Dim item21 As New MenuItem("Google")
            Dim item22 As New MenuItem("Bing")
            Dim item23 As New MenuItem("Yahoo")
            ' Add Click event handlers to menu items
            AddHandler item21.Click, New EventHandler(AddressOf Me.SearchEngineChanged)
            AddHandler item22.Click, New EventHandler(AddressOf Me.SearchEngineChanged)
            AddHandler item23.Click, New EventHandler(AddressOf Me.SearchEngineChanged)
            ' Add menu items to context menu
            item2.MenuItems.Add(item21)
            item2.MenuItems.Add(item22)
            item2.MenuItems.Add(item23)
            Me.contextMenu1.MenuItems.Add(item2)

        End Sub

        ''' <summary>
        ''' Handles Click event for MenuItem
        ''' </summary>
        Private Sub menuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Set text for SearchTextBox control
            Me.searchTextBox1.Text = DirectCast(sender, MenuItem).Text
        End Sub

        ''' <summary>
        ''' Handles Click event for MenuItem
        ''' </summary>
        Private Sub SearchEngineChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim menuItem As MenuItem
            ' Uncheck all menu items
            For Each menuItem In Me.contextMenu1.MenuItems.Item(1).MenuItems
                menuItem.Checked = False
            Next
            ' Check selected menu item
            DirectCast(sender, MenuItem).Checked = True
        End Sub

	End Class

End Namespace