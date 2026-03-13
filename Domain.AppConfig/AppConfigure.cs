namespace Domain.AppConfigure;

public readonly struct AppConfigure(string name, string description, IAppConfigRepository repository)
{
    internal static AppConfigure SaveConfigure(string name, string description)
    {
        return new(name, description, default);
    }

    internal readonly void Export(Action<string, string> export)
    {
        new AppConfigure(name, description, repository).Export(export);
    }
}