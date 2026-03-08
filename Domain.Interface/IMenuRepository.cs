namespace Domain.Menu;

public interface IMenuRepository
{
    Task<string[]> QueryMenu();
}
