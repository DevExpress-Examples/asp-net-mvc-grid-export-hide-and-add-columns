Imports System.Web.Mvc
Imports DevExpress.Web.Mvc

Namespace E4915.Controllers

    Public Class HomeController
        Inherits Controller

        Public Function Index() As ActionResult
            ViewBag.Message = "Welcome to DevExpress Extensions for ASP.NET MVC!"
            Return View()
        End Function

        Public Function Export() As ActionResult
            Dim model = Product.GetProducts()
            Return GridViewExtension.ExportToPdf(ExportHelper.GetGridViewSettings(True), model)
        End Function

        <ValidateInput(False)>
        Public Function GridViewPartial() As ActionResult
            Dim model = Product.GetProducts()
            Return PartialView("_GridViewPartial", model)
        End Function

        Public NotInheritable Class ExportHelper

            Shared Public Function GetGridViewSettings(ByVal isExport As Boolean) As GridViewSettings
                Dim settings As GridViewSettings = New GridViewSettings()
                settings.Name = "GridView"
                settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartial"}
                settings.KeyFieldName = "ProductID"
                settings.Columns.Add("ProductID")
                settings.Columns.Add("ProductName")
                If isExport Then
                    'Columns only to export
                    settings.Columns.Add("UnitsInStock")
                    settings.Columns.Add("UnitsOnOrder")
                Else
                    'Columns only to display on the web page
                    settings.Columns.Add("UnitPrice")
                End If

                Return settings
            End Function
        End Class
    End Class
End Namespace
