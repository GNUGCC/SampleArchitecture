namespace Domain.Command;

public readonly struct Command(Action? execute, Action? unExecute) : ICommand
{
    public static ICommand Create(Action execute, Action? unExecute = default)
    {
        return new Command(execute, unExecute);
    }

    public static ICommand Create(Func<bool> predicate, Action execute, Action? unExecute = default)
    {
        if (predicate.Invoke() is false) return Create(default);
        return Create(execute, unExecute);
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