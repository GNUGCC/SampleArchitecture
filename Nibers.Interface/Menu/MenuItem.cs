using Domain.Command;

namespace Application.Interface.Menu;

public struct MenuItem
{
    string Name { get; }

    string? Description { get; }

    bool Enabled { get; }

    ICommand? Command { get; set; }

    public MenuItem(string name, string? description = default, bool enabled = true)
    {
        Name = name;
        Description = description;
        Enabled = enabled;
    }

    public readonly void Execute()
    {
        Execute(Command);
    }

    public readonly void Execute(ICommand? command)
    {
        if (Enabled is true) command?.Execute();
    }

    public MenuItem SetCommand(ICommand? command)
    {
        Command = command;
        return this;
    }
}