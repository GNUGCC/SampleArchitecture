namespace Domain.Command;

public readonly struct TestCommand : ICommand
{
    void ICommand.Execute()
    {
        throw new NotImplementedException();
    }
}