using Domain.Command;

namespace Application.Interface.Menu;

public readonly struct MenuItem
{
    readonly ICommand? _command;

    string Name { get; }

    string? Description { get; }

    bool Enabled { get; }

    public MenuItem(string name, string? description = default, bool enabled = true, ICommand? command = default)
    {
        Name = name;
        Description = description;
        Enabled = enabled;
        _command = command;
    }

    public readonly void Execute()
    {
        Execute(_command);
    }

    public readonly void Execute(ICommand? command)
    {
        if (Enabled is true) command?.Execute();
    }
}