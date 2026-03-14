namespace Domain.Menu;

public interface IMenuRepository
{
    Task<string[]> QueryMenu();

    Task<string[]> QueryMenuItem();

    Task<int> UpdateMenu(string source, string target);

    Task<int> AddMenu(string menuname);
}