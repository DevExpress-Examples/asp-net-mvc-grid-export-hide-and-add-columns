@Imports E4915.Controllers
@Html.DevExpress().GridView(HomeController.ExportHelper.GetGridViewSettings(false)).Bind(Model).GetHtml()
