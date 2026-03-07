Imports System.Drawing
Namespace CompanionKit.Controls.Utils
	Public Class CustomerData

		Public Shared Function GetCustomers() As List(Of Customer)
			Dim customers As New List(Of Customer)
			customers.Add(New Customer(1, "John", "John", Color.Red))
			customers.Add(New Customer(2, "Charlie", "Charlie", Color.Orange))
			customers.Add(New Customer(3, "Jacob", "Jacob", Color.Yellow))
			customers.Add(New Customer(4, "Steven", "Steven", Color.Green))
			Return customers
		End Function

		Public Shared Function GetCustomersWithImage(ByVal photo As Global.Gizmox.WebGUI.Common.Resources.ResourceHandle) As List(Of Customer)
			Dim customers As List(Of Customer) = CustomerData.GetCustomers
			Dim customer As Customer
			For Each customer In customers
				customer.Photo = photo
			Next
			Return customers
		End Function

	End Class
End Namespace



