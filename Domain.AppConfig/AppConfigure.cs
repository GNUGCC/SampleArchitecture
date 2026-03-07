namespace Domain.AppConfigure;

public readonly struct AppConfigure
{
    string Name { get; }

    string Description { get; }

    AppConfigure(string name, string description)
    {
        Name = name;
        Description = description; 
    }

    public static AppConfigure SaveConfigure(string name, string description)
    {
        return new(name, description);
    }

    public readonly void Export(Action<string, string> export)
    {
        new AppConfigure(Name, Description).Export(export);
    }
}