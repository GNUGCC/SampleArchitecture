using Domain.Menu;
using ServiceHelper;

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
        return ExecuteHelper.Assert(this, context => Task.FromResult(context._menus.Count));
    }

    Task<string[]> IMenuRepository.QueryMenu()
    {
        return ExecuteHelper.Assert(this, context => Task.FromResult(context._menus.ToArray()));
    }

    Task<string[]> IMenuRepository.QueryMenuItem()
    {
        return ExecuteHelper.Assert(() => Task.FromResult<string[]>(["TestMenuItem1", "TestMenuItem2"]));
    }

    Task<int> IMenuRepository.UpdateMenu(string source, string target)
    {
        return ExecuteHelper.Assert(() => Task.FromResult(1));
    }
}
