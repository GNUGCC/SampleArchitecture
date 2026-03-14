namespace Domain.Menu;

public interface IMenuRepository
{
    Task<string[]> QueryMenu();

    Task<int> UpdateMenu(string source, string target);

    Task<int> AddMenu(string menuname);
}