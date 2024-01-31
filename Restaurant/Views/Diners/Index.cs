@{
    Layout = "_Layout";
}

@using Restaurant.Models;

@if(@Model.Count == 0)
{
    <h3>No diners have been added yet</h3>
}

<ul>
    @foreach(Diner diner in Model)
    {
        <li>@Html.ActionLink($"{diner.Name}", "Details", new {id = diner.CuisineId})</li>
    }
</ul>

<p>@Html.ActionLink("add new dinner", "Create")</p>
