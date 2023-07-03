using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace E4915.Controllers
{
public class HomeController : Controller {
        public ActionResult Index() {
            ViewBag.Message = "Welcome to DevExpress Extensions for ASP.NET MVC!";
            return View();
        }

        public ActionResult Export() {
            var model = Product.GetProducts();
            return GridViewExtension.ExportToPdf(ExportHelper.GetGridViewSettings(true), model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial() {
            var model = Product.GetProducts();
            return PartialView("_GridViewPartial", model);
        }

        public static class ExportHelper {
            static public GridViewSettings GetGridViewSettings(bool isExport) {
                GridViewSettings settings = new GridViewSettings();
                settings.Name = "GridView";
                settings.CallbackRouteValues = new {
                    Controller = "Home",
                    Action = "GridViewPartial"
                };

                settings.KeyFieldName = "ProductID";
                settings.Columns.Add("ProductID");
                settings.Columns.Add("ProductName");
                if (isExport) {
                    //Columns only to export
                    settings.Columns.Add("UnitsInStock");
                    settings.Columns.Add("UnitsOnOrder");
                }
                else {
                    //Columns only to display on the web page
                    settings.Columns.Add("UnitPrice");
                }
                return settings;
            }
        }
    }
}
