using Domain.AppConfigure;

namespace Infranstracture.Test;

public readonly struct TestAppConfigRepository : IAppConfigRepository
{
    Task<string?> IAppConfigRepository.LoadAppName()
    {
        throw new NotImplementedException();
    }
}
