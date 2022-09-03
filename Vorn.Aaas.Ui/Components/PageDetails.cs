[AttributeUsage(AttributeTargets.Class)]
public class PageDetails : Attribute
{
    public string Route { get; init; }
    public string Title { get; init; }
    public PageDetails(string route, string title)
    {
        Route = route;
        Title = title;
    }
}
