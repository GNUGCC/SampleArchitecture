using Domain.Menu;

namespace Infranstracture.Test;

public readonly struct TestMenuRepository : IMenuRepository
{
    readonly IList<string> _menus;

    public TestMenuRepository()
    {
        _menus = ["TestMenu1", "TestMenu2"];
    }

    Task<int> IMenuRepository.AddMenu(string menuname)
    {
        _menus.Add(menuname);
        return Task.FromResult(_menus.Count);
    }

    Task<string[]> IMenuRepository.QueryMenu()
    {
        return Task.FromResult(_menus.ToArray());
    }

    Task<int> IMenuRepository.UpdateMenu(string source, string target)
    {
        return Task.FromResult(1);
    }
}
