using Domain.Account;
using ServiceHelper;

namespace Infranstracture.Test;

public readonly struct TestAccountRepository : IAccountRepository
{
    Task<string?> IAccountRepository.QueryAccount(string accountId)
    {
        return ExecuteHelper.Assert(() => Task.FromResult<string?>(accountId));
    }

    Task<string?> IAccountRepository.QueryLine(string id)
    {
        return ExecuteHelper.Assert(() => Task.FromResult<string?>(id));
    }

    Task<string?> IAccountRepository.QueryRole(string id)
    {
        return ExecuteHelper.Assert(() => Task.FromResult<string?>(id));
    }
}
