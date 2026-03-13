using Domain.Command;

namespace Application.Menu;

public readonly struct MenuItem(string name, string? description = default, bool enabled = true, ICommand? command = default)
{
    public readonly void Execute()
    {
        Execute(command);
    }

    internal readonly void Execute(ICommand? command)
    {
        if (enabled is false || command is null) return;
        command.Execute();
    }
}