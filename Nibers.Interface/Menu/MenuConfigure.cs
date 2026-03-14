using Domain.Menu;
using Domain.Command;

namespace Application.Interface.Menu;

public readonly struct MenuConfigure(IMenuRepository repository)
{
    readonly static ICollection<string> _titles = [];
    readonly static ICollection<bool> _enableds = [];
    readonly static ICollection<ICommand> _commands = [];

    public string Title { set { _titles.Add(value); } }

    public bool Enabled { set { _enableds.Add(value); } }

    public ICommand Command { set { _commands.Add(value); } }

    public static IMenuItem[] Build()
    {
        return [.. _titles.Select(x => MenuFactory.CreateMenuItem(x))];
    }
}