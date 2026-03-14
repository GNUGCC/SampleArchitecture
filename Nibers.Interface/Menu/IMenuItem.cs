using Domain.Command;

namespace Application.Interface.Menu;

public interface IMenuItem
{
    string Id { get; }

    ICommand Command { get; }
}