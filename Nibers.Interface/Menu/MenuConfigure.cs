using Domain.Menu;

namespace Application.Interface.Menu;

public readonly struct MenuConfigure(IMenuRepository repository)
{
    readonly static ICollection<string> _titles = [];
    readonly static ICollection<bool> _enableds = [];

    public string Title { set { _titles.Add(value); } }

    public bool Enabled { set { _enableds.Add(value); } }

    internal static MenuItem[] Build()
    {
        return [.. _titles.Select(x => new MenuItem(x))];
    }
}