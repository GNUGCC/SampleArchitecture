namespace Domain.Command;

public interface ICommand
{
    void Execute();

    void UnExecute();
}