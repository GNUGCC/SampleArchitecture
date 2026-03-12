namespace Domain.Menu;

public interface IMenuRepository
{
    Task<string[]> QueryMenu();

    Task<int> UpdateMenu();

    Task<int> AddMenu();
}