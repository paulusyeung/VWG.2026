Imports System.ComponentModel
Imports System.Collections.Generic
Namespace CompanionKit.Controls.PropertyGrid.Functionality
    Public Class DemoObjectConverter
        Inherits TypeConverter
        ' Methods
        Public Overrides Function GetProperties(ByVal context As ITypeDescriptorContext, ByVal value As Object, ByVal attributes As Attribute()) As PropertyDescriptorCollection
            Dim coll As PropertyDescriptorCollection = TypeDescriptor.GetProperties(value, False)
            Dim retval As New List(Of PropertyDescriptor)
            Dim obj As DemoObject = DirectCast(value, DemoObject)
            Dim ix As Integer
            For ix = 0 To coll.Count - 1
                Dim curr As PropertyDescriptor = coll.Item(ix)
                If (DemoObjectConverter.browsableProperties.ContainsKey(curr.Name)) Then
                    If (Not DemoObjectConverter.browsableProperties.Item(curr.Name)) Then
                    Continue For
                End If
                End If
                retval.Add(curr)
            Next ix
            Return New PropertyDescriptorCollection(retval.ToArray)
        End Function

        Public Overrides Function GetPropertiesSupported(ByVal context As ITypeDescriptorContext) As Boolean
            Return True
        End Function


        ' Fields
        Public Shared browsableProperties As Dictionary(Of String, Boolean) = New Dictionary(Of String, Boolean)


    End Class
End Namespace