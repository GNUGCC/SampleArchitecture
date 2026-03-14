namespace Domain.Command;

public readonly struct Command(Action? execute, Action? unExecute) : ICommand
{
    public static ICommand Create(Action execute, Action? unExecute = default)
    {
        return new Command(execute, unExecute);
    }

    void ICommand.Execute()
    {
        execute?.Invoke();
    }

    void ICommand.UnExecute()
    {
        unExecute?.Invoke();
    }
}