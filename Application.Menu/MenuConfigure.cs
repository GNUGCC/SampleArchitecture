using Domain.Menu;

namespace Application.Menu;

public readonly struct MenuConfigure(IMenuRepository repository)
{
    readonly static ICollection<string> _titles = [];
    readonly static ICollection<bool> _enableds = [];

    internal string Title { set { _titles.Add(value); } }

    internal bool Enabled { set { _enableds.Add(value); } }

    internal static MenuItem[] Build()
    {
        return [.. _titles.Select(x => new MenuItem(x))];
    }
}