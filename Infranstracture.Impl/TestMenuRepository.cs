using Domain.Menu;

namespace Infranstracture.Test;

public readonly struct TestMenuRepository : IMenuRepository
{
    Task<int> IMenuRepository.AddMenu()
    {
        throw new NotImplementedException();
    }

    Task<string[]> IMenuRepository.QueryMenu()
    {
        throw new NotImplementedException();
    }

    Task<int> IMenuRepository.UpdateMenu()
    {
        throw new NotImplementedException();
    }
}
