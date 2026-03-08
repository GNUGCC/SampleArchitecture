namespace Application.Interface.Menu;

public readonly struct MenuConfigure
{
    readonly static ICollection<string> _titles = [];
    readonly static ICollection<bool> _enableds = [];

    public string Title { set { _titles.Add(value); } }

    public bool Enabled { set { _enableds.Add(value); } }

    internal void Build()
    {
    }
}