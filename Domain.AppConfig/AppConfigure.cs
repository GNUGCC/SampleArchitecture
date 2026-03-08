namespace Domain.AppConfigure;

public readonly struct AppConfigure
{
    readonly IAppConfigRepository _repository;

    string Name { get; }

    string Description { get; }

    AppConfigure(string name, string description, IAppConfigRepository repository)
    {
        Name = name;
        Description = description;
        _repository = repository;
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