[AttributeUsage(AttributeTargets.Class)]
public class PageDetails : Attribute
{
    public string Route { get; init; }
    public string Title { get; init; }
    public string? Icon { get; init; }
    public PageDetails(string route, string title, string? icon = null)
    {
        Route = route;
        Title = title;
        Icon = icon;
    }
}
