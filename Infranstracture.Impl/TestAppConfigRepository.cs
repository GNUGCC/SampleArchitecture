using Domain.AppConfigure;

namespace Infranstracture.Test;

public readonly struct TestAppConfigRepository : IAppConfigRepository
{
    Task<AppConfigure> IAppConfigRepository.LoadAppConfigure()
    {
        throw new NotImplementedException();
    }
}
