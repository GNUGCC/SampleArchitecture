namespace Domain.Configure;

public struct AppConfigure
{
    public string Name { get; set; }

    public string Description { get; set; }

    public static Task<bool> SaveConfigure()
    {
        return Task.FromResult(true);
    }
}