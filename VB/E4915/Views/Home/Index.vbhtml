@Using Html.BeginForm("Export", "Home")
    @Html.Action("GridViewPartial")
    @<input type="submit" value="Export" />
End Using