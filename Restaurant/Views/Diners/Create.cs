@{
    Layout = "_Layout";
}

@model Restaurant.Models.Diner

<h4>See all Diners</h4>
@using (Html.BeginForm())
{
    @Html.LabelFor(model => model.Name)
    <br />
    @Html.TextBoxFor(model => model.Name, new { placeholder = "Name" })
    <br />
    <br />
    <input type="submit" value="Add Name" />
}

<p>@Html.ActionLink("Show Diners", "Index")</p>