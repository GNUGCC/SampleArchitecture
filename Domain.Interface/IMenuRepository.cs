namespace Domain.Menu;

public interface IMenuRepository
{
    Task<MenuConfigure> QueryMenuConfigure();

    Task<string[]> QueryMenu();
}
