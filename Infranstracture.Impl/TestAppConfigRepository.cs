using Domain.AppConfigure;
using ServiceHelper;

namespace Infranstracture.Test;

public readonly struct TestAppConfigRepository : IAppConfigRepository
{
    Task<string?> IAppConfigRepository.LoadAppName()
    {
        return ExecuteHelper.Assert(() => Task.FromResult<string?>(string.Empty));
    }
}
