Imports System.Collections.Generic
Imports System.Data

Public Class Product

    Private _ProductID As Integer

    Public Property ProductID As Integer
        Get
            Return _ProductID
        End Get

        Protected Set(ByVal value As Integer)
            _ProductID = value
        End Set
    End Property

    Public Property ProductName As String

    Public Property SupplierID As Integer

    Public Property CategoryID As Integer

    Public Property QuantityPerUnit As String

    Public Property UnitPrice As Decimal

    Public Property UnitsInStock As Short

    Public Property UnitsOnOrder As Short

    Public Property ReorderLevel As Short

    Public Property Discontinued As Boolean

    Public Property EAN13 As String

    Private Shared Function GetProductsFromDataTable(ByVal data As DataTable) As List(Of Product)
        If data IsNot Nothing Then
            Dim products As List(Of Product) = New List(Of Product)()
            For Each row As DataRow In data.Rows
                Dim product As Product = New Product() With {.ProductID = CInt(row("ProductID")), .ProductName = CStr(row("ProductName")), .SupplierID = CInt(row("SupplierID")), .CategoryID = CInt(row("CategoryID")), .QuantityPerUnit = CStr(row("QuantityPerUnit")), .UnitPrice = CDec(row("UnitPrice")), .UnitsInStock = CShort(row("UnitsInStock")), .UnitsOnOrder = CShort(row("UnitsOnOrder")), .ReorderLevel = CShort(row("ReorderLevel")), .Discontinued = CBool(row("Discontinued")), .EAN13 = CStr(row("EAN13"))}
                products.Add(product)
            Next

            Return products
        End If

        Return Nothing
    End Function

    Public Shared Function GetProducts() As List(Of Product)
        Dim prodData As DataTable = DataHelper.ProcessSelectCommand("SELECT * FROM [Products]")
        Return GetProductsFromDataTable(prodData)
    End Function

    Public Shared Function GetProducts(ByVal categoryID As Integer) As List(Of Product)
        Dim prodData As DataTable = DataHelper.ProcessSelectCommand("SELECT * FROM [Products] WHERE ([CategoryID] = {0})", categoryID)
        Return GetProductsFromDataTable(prodData)
    End Function
End Class
